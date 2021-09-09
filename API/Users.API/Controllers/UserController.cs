using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
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
        private readonly ILogger _logger;
        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
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
            if (user == null || string.IsNullOrEmpty(user.FullName))
            {
                _logger.LogError("Invalid model");
                return BadRequest();
            }
            try
            {
                var res = await _userService.AddUserAsync(user);
                return CreatedAtAction("AddUser", res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Add user failed");
                throw;
            }
        }

        [HttpPut]
        [Route("user")]
        public async Task<IActionResult> UpdateUserAsync(User user)
        {
            await _userService.UpdateUserAsyn(user);
            return Ok(); 
        }
    }
}
