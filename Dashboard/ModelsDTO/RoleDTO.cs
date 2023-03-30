using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ModelsDTO
{
    public class RoleDTO
    {
        [Required, StringLength(256)]
        public string? Name { get; set; }
    }
}