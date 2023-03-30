namespace WebApplication1.ModelsDTO
{
    public class UserRolesDTo
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public List<RoleDtoModel> Roles { get; set; }
    }
}