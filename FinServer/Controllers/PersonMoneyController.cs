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

        [HttpPost("CreatingCashAccount")]
        public ValidationCreatingMoneyAccountDTO CreatingCashAccount([FromBody] CurrencyNumberIndexDTO dto)
        {
            return _personMoneyService.CheckingTheEnteredData(dto);
        }

        [HttpPost("ReplenishmentCashAccount")]
        public IActionResult ReplenishmentCashAccount([FromBody] MoneyAccountDetailsDTO dto)
        {
            return dto == null? BadRequest() : Ok(_personMoneyService.CheckingTheMoneyEnteredData(dto));
        }

        [HttpGet("UserCashBalance/{id}")]
        public CashAccountBalanceDTO UserCashBalance([FromRoute] Guid id)
        {
            return _personMoneyService.GetPersonMoney(id);
        }

        [HttpGet("UserTransfer/{id}")]
        public TransferHistoryDataDTO UserTransfer([FromRoute] Guid id)
        {
            return _personMoneyService.GetHistoryTransfer(id);
        }


        [HttpGet("ExchangeRateCB")]
        public ExchangeRateCBDTO ExchangeRateCB()
        {
            return _personMoneyService.GetExchangeRateCB();
        }
    }
}
