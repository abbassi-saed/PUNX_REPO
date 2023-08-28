using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PUNX.API.Helpers;
using PUNX.Domain.DTOs;
using PUNX.Domain.Entities;
using PUNX.Domain.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PUNX.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public UsersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserDto>))]
        public async Task<IActionResult> GetAllUsers()
        {
            var usersFromRepo =await _unitOfWork.User.GetAllAsync();
            var userstDtos = _mapper.Map<IEnumerable<UserDto>>(usersFromRepo);
            return Ok(userstDtos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserById(int id)
        {
            var usertFromRepo = await _unitOfWork.User.GetByIdAsync(id);
            if (usertFromRepo == null)
            {
                return NotFound();
            }

            var usertDto = _mapper.Map<UserDto>(usertFromRepo);
            return Ok(usertDto);
        }
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
        {
            if (createUserDto == null)
            {
                return BadRequest();

            }

            // Check if the username or email already exist
            var existingUserByUsername =await _unitOfWork.User.GetByUsernameAsync(createUserDto.Name);
            if (existingUserByUsername != null)
            {
                return BadRequest("Username already exists");
            }

            // Check if the username or email already exist
            var existingUserByEmail = await _unitOfWork.User.GetByEmailAsync(createUserDto.Email);
            if (existingUserByEmail != null)
            {
                return BadRequest("Email already exists");
            }

            string hashedPassword =CommonMethods.ConvertToEncrypt(createUserDto.Password);

            var userEntity = _mapper.Map<User>(createUserDto);
            userEntity.Password = hashedPassword;
            await _unitOfWork.User.AddAsync(userEntity);
            _unitOfWork.Save();

            var userDto = _mapper.Map<UserDto>(userEntity);
            return CreatedAtAction(nameof(GetUserById), new { id = userDto.Id }, userDto);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var userFromRepo = await _unitOfWork.User.GetByIdAsync(id);
            if (userFromRepo == null)
            {
                return NotFound();
            }

            _unitOfWork.User.Remove(userFromRepo);
            _unitOfWork.Save();

            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateUser(int id, string password)
        {
            if (password == null)
            {
                return BadRequest();
            }

            var userFromRepo = await _unitOfWork.User.GetByIdAsync(id);
            if (userFromRepo == null)
            {
                return NotFound();
            }

            string hashedPassword = CommonMethods.ConvertToEncrypt(password);
            userFromRepo.Password = hashedPassword;

            await _unitOfWork.User.UpdateAsync(userFromRepo);
            _unitOfWork.Save();

            var updatedUserDto = _mapper.Map<UserDto>(userFromRepo);
            return Ok(updatedUserDto);
        }

    }
}
