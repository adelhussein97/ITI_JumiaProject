using Microsoft.Build.Framework;

namespace ITI_Jumiaaa.API.Models
{
    public class UserLogin
    {
        // public string UserName { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}