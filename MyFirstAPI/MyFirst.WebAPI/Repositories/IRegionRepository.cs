using MyFirst.WebAPI.Models.Domain;

namespace MyFirst.WebAPI.Repositories
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAllAsync();
    }
}
