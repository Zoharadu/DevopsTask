using Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace DevopsUserApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("createUser")]
        public IActionResult CreateUser([FromBody] UserModel model)
        {
            try
            {
                _userService.CreateUserService(model.id, model.name, model.mail);
                return Ok("User created successfully");
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }

        [HttpGet("readAllUser")]
        public IActionResult ReadAllUser()
        {
            try
            {
                return Ok(_userService.ReadAllUserService());
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }

        [HttpGet("readUser")]
        public IActionResult ReadUser([FromQuery] string id)
        {
            try
            {
                return Ok(_userService.ReadUserService(id));
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }

        [HttpPatch("UpdateUser")]
        public IActionResult UpdateUser([FromBody] UserModel model)
        {
            try
            {
                _userService.UpdateUserService(model.id, model.name, model.mail);
                return Ok("User updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }

        [HttpDelete("deleteUser")]
        public IActionResult DeleteUser([FromQuery] string id)
        {
            try
            {
                return Ok(_userService.DeleteUserService(id));
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }
    }
}
