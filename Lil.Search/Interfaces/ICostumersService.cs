using Lil.Search.Models;

namespace Lil.Search.Interfaces
{
    public interface ICostumersService
    {
        Task<Customer?> GetAsync(string Id);
    }
}
