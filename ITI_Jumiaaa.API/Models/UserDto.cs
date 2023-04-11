using DomainLayer.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace ITI_Jumiaaa.API.ModelsDto
{
    public class UserDto
    {
        [Required, MaxLength(100)]
        public string? FirstName { get; set; }

        [Required, MaxLength(100)]
        public string? LastName { get; set; }

        public string Email { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        // public string? PhoneNumber { get; set; }
    }
}