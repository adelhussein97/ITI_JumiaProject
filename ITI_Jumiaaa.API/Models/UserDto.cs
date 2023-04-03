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
        public string Password { get; set; }=string.Empty;

        //public byte[]? ProfilePicture { get; set; }

        public string? City { get; set; }

        public string? FullAddress { get; set; }
        public Gender? GenderId { get; set; }
        public Governorate? GovernorateId { get; set; }

        public string? PhoneNumber { get; set; }
    }
}
