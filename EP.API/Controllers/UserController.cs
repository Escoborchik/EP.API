using EP.API.DTO;
using EP.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(UserRequest userRequest)
        {
            await _userService.Register(userRequest.Email, userRequest.Password);
            return Ok();
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(UserRequest userRequest)
        {

            try
            {
                var token = await _userService.Login(userRequest.Email, userRequest.Password);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

             

            
        }
    }
}
