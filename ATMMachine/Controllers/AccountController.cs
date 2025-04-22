using ATMMachine.Business.Interfaces;
using ATMMachine.DTOs;
using ATMMachine.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATMMachine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountManager _accountManager;
        private readonly ILogger<AccountController> _logger;
        public AccountController(AccountManager _accountManager, ILogger<AccountController> logger)
        {
            this._accountManager = _accountManager;
            _logger = logger;
        }

        [HttpPost("withdraw")]
        public async Task<IActionResult> WithdrawalMoney(WithdrawalDTO withdrawalDTO)
        {
            try
            {
                return Ok(await this._accountManager.WithdrawalMoney(withdrawalDTO));
            }
            catch (CardBlockedException ex)
            {
                this._logger.LogInformation(ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (InsufficientBalanceException ex)
            {
                this._logger.LogInformation(ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (DailyLimitExceededException ex)
            {
                this._logger.LogInformation(ex.Message);
                return StatusCode(StatusCodes.Status200OK, ex.Message);
            }
            catch (NotFoundException ex)
            {
                this._logger.LogInformation(ex.Message);
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,ex.Message);
            }
        }

        [HttpPost("deposit")]
        public async Task<IActionResult> DepositMoney(DepositRequestDTO depositRequestDTO)
        {
            try
            {
                return Ok(await this._accountManager.DepositMoney(depositRequestDTO));
            }
            catch (NotFoundException ex)
            {
                this._logger.LogInformation(ex.Message);
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
            catch (CardBlockedException ex)
            {
                this._logger.LogInformation(ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("balance")]
        public async Task<IActionResult> CheckBalance([FromQuery] string cardNumber)
        {
            try
            {
                return Ok((await this._accountManager.GetAccount(cardNumber)).Balance);
            }
            catch (NotFoundException ex)
            {
                this._logger.LogInformation(ex.Message);
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
