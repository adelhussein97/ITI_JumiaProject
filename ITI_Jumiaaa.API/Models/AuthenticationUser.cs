namespace ITI_Jumiaaa.API.Models
{
    public class AuthenticationUser
    {
        public string? Message { get; set; }
        public bool IsAuthenticated { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string? Email { get; set; }
        public List<string>? RolesList { get; set; }
        public string? Token { get; set; }
        public DateTime? ExpireOn { get; set; }

    }
}
