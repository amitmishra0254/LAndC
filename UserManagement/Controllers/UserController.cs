using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagement.DTOs;
using UserManagement.Exceptions;
using UserManagement.Manager;

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager userManager;
        private readonly ILogger<UserController> logger;

        public UserController(UserManager userManager, ILogger<UserController> logger)
        {
            this.userManager = userManager;
            this.logger = logger;

        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserDTO user)
        {
            try
            {
                return Ok(await this.userManager.CreateUser(user));
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{Id:int:min(1)}")]
        public async Task<IActionResult> GetUser([FromRoute] int Id)
        {
            try
            {
                return Ok(await this.userManager.GetUser(Id));
            }
            catch (NotFoundException ex)
            {
                this.logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{Id:int:min(1)}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int Id)
        {
            try
            {
                return Ok(await this.userManager.DeleteUser(Id));
            }
            catch (NotFoundException ex)
            {
                this.logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{Id:int:min(1)}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int Id, [FromBody] UserDTO user)
        {
            try
            {
                return Ok(await this.userManager.UpdateUser(Id, user));
            }
            catch (NotFoundException ex)
            {
                this.logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
