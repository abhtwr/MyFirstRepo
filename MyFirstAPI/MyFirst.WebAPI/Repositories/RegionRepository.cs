using Microsoft.EntityFrameworkCore;
using MyFirst.WebAPI.Data;
using MyFirst.WebAPI.Models.Domain;

namespace MyFirst.WebAPI.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext nZWalksDbContext;

        public RegionRepository(NZWalksDbContext nZWalksDbContext)
        {
            this.nZWalksDbContext = nZWalksDbContext;
        }
        async Task<IEnumerable<Region>> IRegionRepository.GetAllAsync()
        {
            return await nZWalksDbContext.Regions.ToListAsync();
        }
    }
}
