using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Users.Domain.Interfaces.Services;
using Users.Domain.Models;

namespace Users.API.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("users")]
        public async Task<IActionResult> GetUsersAsync()
        {
            var result = await _userService.GetUsersAsync();
            return Ok(result);
        }

        [HttpPost]
        [Route("user")]
        public async Task<IActionResult> AddUserAsync(User user)
        {
            var res = await _userService.AddUserAsync(user);
            return CreatedAtAction("AddUser", res);
        }
    }
}
