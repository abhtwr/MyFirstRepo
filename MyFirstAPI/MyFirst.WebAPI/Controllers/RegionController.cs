using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetAllRegion()
        {
            var Region = await regionRepository.GetAllAsync();
            var RegionDTO = mapper.Map<List<Models.DTO.Region>>(Region);
            return Ok(RegionDTO);
        }
    }
}
