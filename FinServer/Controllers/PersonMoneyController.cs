using FinCommon.DTO;
using FinServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonMoneyController : ControllerBase
    {
        private readonly PersonMoneyService _personMoneyService;

        public PersonMoneyController()
        {
            _personMoneyService = new PersonMoneyService();
        }

        /// <summary>
        /// Создание финансового счета
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("CreatingCashAccount")]
        public ValidationCreatingMoneyAccountDTO CreatingCashAccount([FromBody] CurrencyNumberIndexDTO dto)
        {
            return _personMoneyService.CheckingTheEnteredData(dto);
        }

        /// <summary>
        /// Пополнение денег финансового счета
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("ReplenishmentCashAccount")]
        public IActionResult ReplenishmentCashAccount([FromBody] MoneyAccountDetailsDTO dto)
        {
            return dto == null? BadRequest() : Ok(_personMoneyService.CheckingTheMoneyEnteredData(dto));
        }

        /// <summary>
        /// Получение баланса счетов
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("UserCashBalance/{id}")]
        public CashAccountBalanceDTO UserCashBalance([FromRoute] Guid id)
        {
            return _personMoneyService.GetPersonMoney(id);
        }

        /// <summary>
        /// Получение курса валют с официального сайта ЦБ
        /// </summary>
        /// <returns></returns>
        [HttpGet("ExchangeRateCB")]
        public ExchangeRateCBDTO ExchangeRateCB()
        {
            return _personMoneyService.GetExchangeRateCB();
        }

        /// <summary>
        /// Перевод денег другому лицу
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("MoneyTransfer")]
        public ValidationMoneyTransferResultDTO MoneyTransfer([FromBody] MoneyTransferDTO dto)
        {
            return _personMoneyService.TransferMoneyAnotherUser(dto);
        }

        /// <summary>
        /// Обмен денег
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("MoneyExchange")]
        public ValidationMoneyExchangeResultDTO MoneyExchange([FromBody] MoneyExchangeDTO dto)
        {
            return _personMoneyService.ExchangeMoneyUser(dto);
        }

    }
}
