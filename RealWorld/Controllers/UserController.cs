using Microsoft.AspNetCore.Mvc;
using RealWorld.Contract;
using RealWorld.Mappers;
using RealWorld.Model;
using RealWorld.Services;

namespace RealWorld.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetAll() 
        {
            try {

                IEnumerable<User> users = await _userService.GetAllAsync();
                
                if (!users.Any()) 
                    return NoContent();

                var usersResponse = users.Select(x => x.ToUserResponse());

                return Ok(usersResponse);
            }
            catch (Exception ex) 
            {
                return StatusCode(500); 
            }
        }

        [HttpGet("users/{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user is null)
            {
                return NotFound();
            }

            var userResponse = user.ToUserResponse();

            return Ok(userResponse);
        }

        [HttpPost("users")]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest createUserRequest)
        {
            var user = new User
            {
                FullName = createUserRequest.FullName
            };

            var created = await _userService.CreateAsync(user);
            if (!created)
            {
                // Implement validation
                return BadRequest();
            }

            var userResponse = user.ToUserResponse();

            return CreatedAtAction(
                nameof(GetById),
                new { id = userResponse.Id }, userResponse);
        }

        [HttpDelete("users/{id:guid}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            var deleted = await _userService.DeleteByIdAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return Ok();
        }

    }
}