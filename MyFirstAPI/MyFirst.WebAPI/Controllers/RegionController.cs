using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyFirst.WebAPI.Models.Domain;
using MyFirst.WebAPI.Models.DTO;
using MyFirst.WebAPI.Repositories;

namespace MyFirst.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionController : Controller
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionController(IRegionRepository regionRepository, IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRegionAsync()
        {
            var Region = await regionRepository.GetAllAsync();
            var RegionDTO = mapper.Map<List<Models.DTO.Region>>(Region);
            return Ok(RegionDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetRegionAsync")]
        public async Task<IActionResult> GetRegionAsync(Guid id)
        {
            var Region = await regionRepository.GetAsync(id);
            if (Region == null)
            {
                return NotFound();
            }
            var RegionDTO = mapper.Map<Models.DTO.Region>(Region);
            return Ok(RegionDTO);

        }
        [HttpPost]
        public async Task<IActionResult> AddRegionAsync(AddRegionRequest addRegionRequest)
        {
            var region = new Models.Domain.Region
            {
                Code = addRegionRequest.Code,
                Name = addRegionRequest.Name,
                Area = addRegionRequest.Area,
                Lat = addRegionRequest.Lat,
                Long = addRegionRequest.Long,
                Population = addRegionRequest.Population,
            };
            region = await regionRepository.AddAsync(region);
            var regionDTO = new Models.DTO.Region
            {
                Id = region.Id,
                Name = region.Name,
                Code = region.Code,
                Area = region.Area,
                Lat=region.Lat,
                Long=region.Long,
                Population=region.Population,
            };
            return CreatedAtAction(nameof(GetRegionAsync), new { id = regionDTO.Id }, regionDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegionAsync(Guid id)
        {
            var region = await regionRepository.GetAsync(id);
            if (region == null)
            {
                return NotFound();
            }
            region = await regionRepository.DeleteAsync(id);
            var regionDTO = new Models.DTO.Region
            {
                Id = region.Id,
                Name = region.Name,
                Code = region.Code,
                Area = region.Area,
                Lat = region.Lat,
                Long = region.Long,
                Population = region.Population,
            };
            return Ok(regionDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateRegionAsync([FromRoute] Guid id, [FromBody] Models.DTO.UpdateRegionRequest updateRegionRequest)
        {
            var region = new Models.Domain.Region
            {
                Code = updateRegionRequest.Code,
                Name = updateRegionRequest.Name,
                Area = updateRegionRequest.Area,
                Lat = updateRegionRequest.Lat,
                Long = updateRegionRequest.Long,
                Population = updateRegionRequest.Population,
            };
            region = await regionRepository.UpdateAsync(id, region);
            if(region == null)
            {
                return NotFound();
            }
            var regionDTO = new Models.DTO.Region
            {
                Id = region.Id,
                Name = region.Name,
                Code = region.Code,
                Area = region.Area,
                Lat = region.Lat,
                Long = region.Long,
                Population = region.Population,
            };

            return Ok(regionDTO);
        }
    }
}
