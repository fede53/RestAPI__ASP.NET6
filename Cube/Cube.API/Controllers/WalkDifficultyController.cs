using AutoMapper;
using Cube.Api.Models.Domain;
using Cube.Api.Models.DTO;
using Cube.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cube.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalkDifficultyController : Controller
    {
        private readonly IWalkDifficultyRepository walkDifficultyRepository;
        private readonly IMapper mapper;

        public WalkDifficultyController(IWalkDifficultyRepository walkDifficultyRepository, IMapper mapper)
        {
            this.walkDifficultyRepository = walkDifficultyRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var walkDifficulty = await walkDifficultyRepository.GetAllAsync();
            return Ok(mapper.Map<List<WalkDifficultyDTO>>(walkDifficulty));
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid Id)
        {
            var walkDifficulty = await walkDifficultyRepository.GetAsync(Id);
            if (walkDifficulty == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<WalkDifficultyDTO>(walkDifficulty));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddWalkDifficultyDTO addWalkDifficultyRequest)
        {
            var walkDifficulty = new WalkDifficulty()
            {
                Code = addWalkDifficultyRequest.Code,
            };

            var response = await walkDifficultyRepository.AddAsync(walkDifficulty);
            var walkDifficultyDTO = mapper.Map<WalkDifficultyDTO>(walkDifficulty);
            return CreatedAtAction(nameof(Get), new { id = walkDifficultyDTO.Id }, walkDifficultyDTO);

        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid Id, [FromBody] UpdateWalkDifficultyDTO updateWalkDifficultyRequest)
        {
            //var walkDifficultyModel = mapper.Map<WalkDifficulty>(updateWalkDifficultyRequest);
            var walkDifficultyModel = new WalkDifficulty()
            {
                Code = updateWalkDifficultyRequest.Code,
            };

            var walkDifficulty = await walkDifficultyRepository.UpdateAsync(Id, walkDifficultyModel);
            if (walkDifficulty == null)
            {
                return NotFound();
            }
            var walkDifficultyDTO = mapper.Map<WalkDifficultyDTO>(walkDifficulty);
            return Ok(walkDifficultyDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid Id)
        {
            var walkDifficulty = await walkDifficultyRepository.DeleteAsync(Id);
            if (walkDifficulty == null)
            {
                return NotFound();
            }

            var walkDifficultyDTO = mapper.Map<WalkDifficultyDTO>(walkDifficulty);
            return Ok(walkDifficultyDTO);
        }

    }
}
