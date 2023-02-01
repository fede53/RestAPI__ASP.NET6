using AutoMapper;
using Cube.RestApi.Models.Entities;
using Cube.RestApi.Models.DTO;
using Cube.RestApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Cube.RestApi.Repositories;
using System.Diagnostics;

namespace Cube.RestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private readonly IRoleRepository roleRepository;

        public UsersController(IUserRepository userRepository, IMapper mapper, IRoleRepository roleRepository)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.roleRepository = roleRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var users = await userRepository.GetAllAsync();
            return Ok(mapper.Map<List<UserDTO>>(users));
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int Id)
        {
            var user = await userRepository.GetAsync(Id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<UserDTO>(user));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddUserDTO addUserRequest)
        {
            Role role = await roleRepository.GetAsync(addUserRequest.RoleId);
            var user = new User()
            {
                FirstName = addUserRequest.FirstName,
                LastName = addUserRequest.LastName,
                Email = addUserRequest.Email,
                Password = addUserRequest.Password,
                Role = role
            };

            var response = await userRepository.AddAsync(user);
            var userDTO = mapper.Map<UserDTO>(user);
            return CreatedAtAction(nameof(Get), new { id = userDTO.Id }, userDTO);

        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int Id, [FromBody] UpdateUserDTO updateUserRequest)
        {
            Role role = await roleRepository.GetAsync(updateUserRequest.RoleId);
            var userModel = new User()
            {
                FirstName = updateUserRequest.FirstName,
                LastName = updateUserRequest.LastName,
                Email = updateUserRequest.Email,
                Password = updateUserRequest.Password,
                Role = role
            };

            var user = await userRepository.UpdateAsync(Id, userModel);
            if (user == null)
            {
                return NotFound();
            }
            var userDTO = mapper.Map<UserDTO>(user);
            return Ok(userDTO);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            var user = await userRepository.DeleteAsync(Id);
            if (user == null)
            {
                return NotFound();
            }

            var userDTO = mapper.Map<UserDTO>(user);
            return Ok(userDTO);
        }

    }
}
