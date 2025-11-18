using ClinicManagementSystem.Application.AuthInterface;
using ClinicManagementSystem.Domain.Config;
using ClinicManagementSystem.Domain.Dtos;
using ClinicManagementSystem.Domain.Models;
using ClinicManagementSystem.Service.AuthService;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMemoryCache _memoryCache;
        private readonly EmailSetting _emailSettings;

        public UserService(
            IUserRepository userRepository,
            IMemoryCache memoryCache,
            IOptions<EmailSetting> emailSettings)
        {
            _userRepository = userRepository;
            _memoryCache = memoryCache;
            _emailSettings = emailSettings.Value;
        }

        public async Task<User> CreateAsync(UserCreateDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var existingUser = await _userRepository.GetByEmailAsync(dto.Email);
            if (existingUser != null)
                throw new InvalidOperationException("User with this email already exists.");

            var user = new User
            {
                UserID = Guid.NewGuid(),
                Name = dto.FullName,
                Email = dto.Email,
                Password = dto.Password,
                PhoneNumber = dto.PhoneNumber,
                RoleID = 1,
                IsActive = false,
                CreatedAt = DateTime.UtcNow
            };

            await _userRepository.CreateAsync(user);
            await SendOtpAsync(dto.Email);

            return user;
        }

        public async Task<IEnumerable<User>> GetAllAsync() => await _userRepository.GetAllAsync();

        public async Task<User> GetByIdAsync(Guid id) => await _userRepository.GetByIdAsync(id);

        public async Task<User> UpdateAsync(Guid id, UserUpdateDto dto)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                throw new KeyNotFoundException("User not found");

            user.Name = dto.FullName;
            user.Email = dto.Email;
            user.Password = dto.Password;
            user.PhoneNumber = dto.PhoneNumber;

            return await _userRepository.UpdateAsync(user);
        }

        public async Task<bool> DeleteAsync(Guid id) => await _userRepository.DeleteAsync(id);




        public async Task<bool> SendOtpAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("Email cannot be empty.", nameof(email));

            var otp = new Random().Next(100000, 999999).ToString();

            _memoryCache.Set(email, otp, TimeSpan.FromMinutes(5));

            try
            {
                using var smtpClient = new SmtpClient(_emailSettings.SmtpServer)
                {
                    Port = _emailSettings.SmtpPort,
                    Credentials = new NetworkCredential(_emailSettings.SenderEmail, _emailSettings.Password),
                    EnableSsl = _emailSettings.EnableSsl
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_emailSettings.SenderEmail, _emailSettings.SenderName),
                    Subject = "Your OTP for Signup Verification",
                    Body = $"Your OTP is {otp}. It expires in 1 minutes.",
                    IsBodyHtml = false
                };

                mailMessage.To.Add(email);

                await smtpClient.SendMailAsync(mailMessage);
                return true;
            }
            catch (SmtpException ex)
            {
                throw new InvalidOperationException($"Failed to send OTP email: {ex.Message}", ex);
            }
        }

        public async Task<bool> VerifyOtpAsync(string email, string otp)
        {
            if (_memoryCache.TryGetValue(email, out string cachedOtp))
            {
                if (cachedOtp == otp)
                {
                    var user = await _userRepository.GetByEmailAsync(email);
                    if (user != null)
                    {
                        user.IsActive = true;
                        await _userRepository.UpdateAsync(user);
                    }

                    _memoryCache.Remove(email);
                    return true;
                }
            }

            return false;
        }
    }
}
