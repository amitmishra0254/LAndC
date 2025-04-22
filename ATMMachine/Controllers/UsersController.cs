using ATMMachine.Business.Interfaces;
using ATMMachine.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATMMachine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager _userManager;
        private readonly ILogger<UsersController> logger;
        public UsersController(UserManager _userManager, ILogger<UsersController> logger)
        {
            this._userManager = _userManager;
            this.logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequestDTO createUserRequestDTO)
        {
            try
            {
                return CreatedAtAction(nameof(CreateUser), createUserRequestDTO, await this._userManager.CreateUser(createUserRequestDTO));
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
