using WebApplication1.Models;

namespace ITI_Jumiaaa.API.ModelsDto
{
    public class User:ApplicationUser
    {
       // public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        


    }
}
