using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;

namespace WebApplication1.ModelsDTO
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}