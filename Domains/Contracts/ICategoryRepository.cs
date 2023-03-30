using Domains;
using WebApplication1.Models;

namespace Domains.Contracts
{
    public interface ICategoryRepository : IRepository<Category, int>
    {
        Task<Category> FilterByAsync(string? filter = null);
    }
}
