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

        public async Task<Region> AddAsync(Region region)
        {
            region.Id = Guid.NewGuid();
            await nZWalksDbContext.Regions.AddAsync(region);
            await nZWalksDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region> DeleteAsync(Guid id)
        {
            var region = await nZWalksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (region == null)
            {
                return null;
            }
            nZWalksDbContext.Regions.Remove(region);
            nZWalksDbContext.SaveChanges();
            return region;

        }

        public async Task<Region> GetAsync(Guid id)
        {
            return await nZWalksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region> UpdateAsync(Guid id, Region region)
        {
            var existingRegion = await nZWalksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegion == null)
            {
                return null;
            }
            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.Area = region.Area;
            existingRegion.Lat = region.Lat;
            existingRegion.Long = region.Long;
            existingRegion.Population = region.Population;
            await nZWalksDbContext.SaveChangesAsync();
            return existingRegion;
        }

        async Task<IEnumerable<Region>> IRegionRepository.GetAllAsync()
        {
            return await nZWalksDbContext.Regions.ToListAsync();
        }
    }
}
