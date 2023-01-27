using AutoMapper;
using Cube.API.Models.Domain;
using Cube.API.Models.DTO;
using Cube.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Cube.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionsController : Controller
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regions = await regionRepository.GetAllAsync();
            var regionsDTO = mapper.Map<List<RegionDTO>>(regions);
            return Ok(regionsDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid Id)
        {
            var region = await regionRepository.GetAsync(Id);
            if (region == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<RegionDTO>(region));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddRegionDTO addRegionRequest)
        {
            var region = new Region()
            {
                Code = addRegionRequest.Code,
                Area = addRegionRequest.Area,
                Lat = addRegionRequest.Lat,
                Long = addRegionRequest.Long,
                Name = addRegionRequest.Name,
                Population = addRegionRequest.Population
            };

            var response = await regionRepository.AddAsync(region);
            var regionDTO = mapper.Map<RegionDTO>(region);
            return CreatedAtAction(nameof(Get), new { id = regionDTO.Id }, regionDTO);

        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid Id, [FromBody] UpdateRegionDTO updateRegionRequest)
        {
            //var regionModel = mapper.Map<Region>(updateRegionRequest);
            var regionModel = new Region()
            {
                Code = updateRegionRequest.Code,
                Area = updateRegionRequest.Area,
                Lat = updateRegionRequest.Lat,
                Long = updateRegionRequest.Long,
                Name = updateRegionRequest.Name,
                Population = updateRegionRequest.Population
            };

            var region = await regionRepository.UpdateAsync(Id, regionModel);
            if (region == null)
            {
                return NotFound();
            }
            var regionDTO = mapper.Map<RegionDTO>(region);
            return Ok(regionDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid Id)
        {
            var region = await regionRepository.DeleteAsync(Id);
            if (region == null)
            {
                return NotFound();
            }

            var regionDTO = mapper.Map<RegionDTO>(region);
            return Ok(regionDTO);
        }

    }
}
