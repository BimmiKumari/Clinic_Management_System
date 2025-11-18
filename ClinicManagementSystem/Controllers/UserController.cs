

using ClinicManagementSystem.Domain.Dtos;
using ClinicManagementSystem.Service.AuthService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody] UserCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userService.CreateAsync(dto);
            return Ok(new
            {
                message = "Signup successful!",
                user
            });
            
        }

            [HttpPost("verify-otp")]
        public async Task<IActionResult> VerifyOtp([FromBody] OtpVerifyDto dto)
        {
            var result = await _userService.VerifyOtpAsync(dto.Email, dto.Otp);
            return result ? Ok("OTP verified, account activated!") : BadRequest("Invalid or expired OTP.");
        }

        [HttpPost("send-otp")]
        public async Task<IActionResult> SendOtp([FromBody] string email)
        {
            try
            {
                var result = await _userService.SendOtpAsync(email);
                return result ? Ok("OTP sent successfully!") : BadRequest("Failed to send OTP.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error sending OTP: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UserUpdateDto dto)
        {
            var user = await _userService.UpdateAsync(id, dto);
            return user != null ? Ok(user) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _userService.DeleteAsync(id);
            return deleted ? Ok("Deleted successfully") : NotFound();
        }
    }
}
