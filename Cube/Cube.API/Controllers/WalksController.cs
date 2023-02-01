using AutoMapper;
using Cube.Api.Models.Domain;
using Cube.Api.Models.DTO;
using Cube.Api.Repositories;
using Cube.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cube.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalksController : Controller
    {
        private readonly IWalkRepository walkRepository;
        private readonly IMapper mapper;
        private readonly IRegionRepository regionRepository;
        private readonly IWalkDifficultyRepository walkDifficultyRepository;


        public WalksController(IWalkRepository walkRepository, IMapper mapper, IRegionRepository regionRepository, IWalkDifficultyRepository walkDifficultyRepository)
        {
            this.walkRepository = walkRepository;
            this.mapper = mapper;
            this.regionRepository = regionRepository;
            this.walkDifficultyRepository = walkDifficultyRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var walks = await walkRepository.GetAllAsync();
            return Ok(mapper.Map<List<WalkDTO>>(walks));
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid Id)
        {
            var walk = await walkRepository.GetAsync(Id);
            if (walk == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<WalkDTO>(walk));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddWalkDTO addWalkRequest)
        {
            if (!(await ValidateAddWalkAsync(addWalkRequest)))
            {
                return BadRequest(ModelState);
            }

            var walk = new Walk()
            {
                Name = addWalkRequest.Name,
                Length = addWalkRequest.Length,
                RegionId = addWalkRequest.RegionId,
                WalkDifficultyId = addWalkRequest.WalkDifficultyId
            };

            var response = await walkRepository.AddAsync(walk);
            var walkDTO = mapper.Map<WalkDTO>(walk);
            return CreatedAtAction(nameof(Get), new { id = walkDTO.Id }, walkDTO);

        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid Id, [FromBody] UpdateWalkDTO updateWalkRequest)
        {
            if (!(await ValidateUpdateWalkAsync(updateWalkRequest)))
            {
                return BadRequest(ModelState);
            }
            //var walkModel = mapper.Map<Walk>(updateWalkRequest);
            var walkModel = new Walk()
            {
                Name = updateWalkRequest.Name,
                Length = updateWalkRequest.Length,
                RegionId = updateWalkRequest.RegionId,
                WalkDifficultyId = updateWalkRequest.WalkDifficultyId
            };

            var walk = await walkRepository.UpdateAsync(Id, walkModel);
            if (walk == null)
            {
                return NotFound();
            }
            var walkDTO = mapper.Map<WalkDTO>(walk);
            return Ok(walkDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid Id)
        {
            var walk = await walkRepository.DeleteAsync(Id);
            if (walk == null)
            {
                return NotFound();
            }

            var walkDTO = mapper.Map<WalkDTO>(walk);
            return Ok(walkDTO);
        }


        #region Private methods
        private async Task<bool> ValidateAddWalkAsync(AddWalkDTO addWalkRequest)
        {

            var region = await regionRepository.GetAsync(addWalkRequest.RegionId);
            if (region == null)
            {
                ModelState.AddModelError(nameof(addWalkRequest.RegionId),
                    $"{nameof(addWalkRequest.RegionId)} is invalid.");
            }

            var walkDifficulty = await walkDifficultyRepository.GetAsync(addWalkRequest.WalkDifficultyId);
            if (walkDifficulty == null)
            {
                ModelState.AddModelError(nameof(addWalkRequest.WalkDifficultyId),
                       $"{nameof(addWalkRequest.WalkDifficultyId)} is invalid.");

            }

            if (ModelState.ErrorCount > 0)
            {
                return false;
            }

            return true;
        }

        private async Task<bool> ValidateUpdateWalkAsync(UpdateWalkDTO updateWalkRequest)
        {

            var region = await regionRepository.GetAsync(updateWalkRequest.RegionId);
            if (region == null)
            {
                ModelState.AddModelError(nameof(updateWalkRequest.RegionId),
                    $"{nameof(updateWalkRequest.RegionId)} is invalid.");
            }

            var walkDifficulty = await walkDifficultyRepository.GetAsync(updateWalkRequest.WalkDifficultyId);
            if (walkDifficulty == null)
            {
                ModelState.AddModelError(nameof(updateWalkRequest.WalkDifficultyId),
                       $"{nameof(updateWalkRequest.WalkDifficultyId)} is invalid.");

            }

            if (ModelState.ErrorCount > 0)
            {
                return false;
            }

            return true;
        }
        #endregion



    }
}
