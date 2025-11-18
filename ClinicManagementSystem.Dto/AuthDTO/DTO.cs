using System.ComponentModel.DataAnnotations;

namespace ClinicManagementSystem.Domain.Dtos
{
    public class UserDto
    {
        public Guid UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public long PhoneNumber { get; set; }
        public int RoleID { get; set; }
        public bool IsActive { get; set; }
    }

    public class UserCreateDto
    {
        [Required]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(6)]
        public string Password { get; set; }

        [Required]
        public long PhoneNumber { get; set; }

    }

    public class UserUpdateDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public long PhoneNumber { get; set; }
    }

    public class OtpVerifyDto
    {
        public string Email { get; set; }
        public string Otp { get; set; }
    }
}
