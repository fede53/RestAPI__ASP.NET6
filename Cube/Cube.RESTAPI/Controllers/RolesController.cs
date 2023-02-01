using AutoMapper;
using Cube.RestApi.Models.Entities;
using Cube.RestApi.Models.DTO;
using Cube.RestApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Cube.RestApi.Repositories;

namespace Cube.RestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RolesController : Controller
    {
        private readonly IRoleRepository roleRepository;
        private readonly IMapper mapper;

        public RolesController(IRoleRepository roleRepository, IMapper mapper)
        {
            this.roleRepository = roleRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roles = await roleRepository.GetAllAsync();
            return Ok(mapper.Map<List<RoleDTO>>(roles));
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int Id)
        {
            var role = await roleRepository.GetAsync(Id);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<RoleDTO>(role));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddRoleDTO addRoleRequest)
        {
            var role = new Role()
            {
                Name = addRoleRequest.Name
            };

            var response = await roleRepository.AddAsync(role);
            var roleDTO = mapper.Map<RoleDTO>(role);
            return CreatedAtAction(nameof(Get), new { id = roleDTO.Id }, roleDTO);

        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int Id, [FromBody] UpdateRoleDTO updateRoleRequest)
        {
            var roleModel = new Role()
            {
                Name = updateRoleRequest.Name
            };

            var role = await roleRepository.UpdateAsync(Id, roleModel);
            if (role == null)
            {
                return NotFound();
            }
            var roleDTO = mapper.Map<RoleDTO>(role);
            return Ok(roleDTO);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            var role = await roleRepository.DeleteAsync(Id);
            if (role == null)
            {
                return NotFound();
            }

            var roleDTO = mapper.Map<RoleDTO>(role);
            return Ok(roleDTO);
        }

    }
}
