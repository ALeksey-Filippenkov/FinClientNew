using FinCommon.DTO;
using FinServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersMonetaryTransactionsController : ControllerBase
    {
        private readonly UsersMonetaryTransactionsService _usersMonetaryTransactionsService;

        public UsersMonetaryTransactionsController()
        {
            _usersMonetaryTransactionsService = new UsersMonetaryTransactionsService();
        }

        /// <summary>
        /// Перевод денег другому лицу
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("MoneyTransfer")]
        public IActionResult MoneyTransfer([FromBody] MoneyTransferDTO dto)
        {
            return dto == null ? BadRequest() : Ok(_usersMonetaryTransactionsService.TransferMoneyAnotherUser(dto));
        }



    }
}
