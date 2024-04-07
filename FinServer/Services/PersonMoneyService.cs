using FinCommon.DTO;
using FinServer.AdditionalClasses;
using FinServer.DbModels;
using FinServer.Enum;
using System.Net;
using System.Xml.Linq;
using FinServer.GeneralMethodsServer;

namespace FinServer.Services
{
    public class PersonMoneyService
    {
        private readonly ApplicationContext _context;

        public PersonMoneyService()
        {
            _context = new ApplicationContext();
        }

        public ValidationCreatingMoneyAccountDTO CheckingTheEnteredData(CurrencyNumberIndexDTO dto)
        {
            if (dto.Index == -1)
            {
                return new ValidationCreatingMoneyAccountDTO
                {
                    IsSuccess = false,
                    Message = "Вы не выбрали валюту для счета"
                };
            }

            return CreatingCashAccount(dto);
        }

        private ValidationCreatingMoneyAccountDTO CreatingCashAccount(CurrencyNumberIndexDTO dto)
        {
            _context.Add(new DbPersonMoney()
            {
                PersonId = dto.PersonId,
                Id = Guid.NewGuid(),
                Type = (CurrencyType)dto.Index,
                Balance = 0
            });

            _context.SaveChanges();

            return new ValidationCreatingMoneyAccountDTO
            {
                IsSuccess = true,
                Message = "Счет успешно создан!"
            };
        }

        public ValidationMoneyReplenishmentDTO CheckingTheMoneyEnteredData(MoneyAccountDetailsDTO dto)
        {
            var moneyValue = double.TryParse(dto.Balance, out var moneyDouble);

            if (!moneyValue)
            {
                return new ValidationMoneyReplenishmentDTO
                {
                    IsSuccess = false,
                    Message = "Вы ввели не число."
                };
            }

            var moneyAccount = CommonMethodServer.GetSearchAccountOwner(dto.Index, dto.PersonId, _context);
            if (moneyAccount == null)
            {
                return new ValidationMoneyReplenishmentDTO
                {
                    IsSuccess = false,
                    Message = "Счета с таким видом валюты не найден"
                };
            }

            return AddingMoneyToTheAccount(dto, moneyAccount, moneyDouble);
        }

        public ValidationMoneyReplenishmentDTO AddingMoneyToTheAccount(MoneyAccountDetailsDTO dto, DbPersonMoney moneyAccount, double moneyDouble)
        {
            moneyAccount.Balance += moneyDouble;
            AddingMoneyToTheHistory(dto, moneyDouble);
            _context.SaveChanges();

            return new ValidationMoneyReplenishmentDTO
            {
                IsSuccess = true,
                Message = "Деньги успешно зачислены на счет"
            };
        }

        private void AddingMoneyToTheHistory(MoneyAccountDetailsDTO dto, double moneyDouble)
        {
            var historyTransfer = new DbHistoryTransfer
            {
                Id = Guid.NewGuid(),
                SenderId = dto.PersonId,
                RecipientId = dto.PersonId,
                DateTime = DateTime.Now,
                Type = (CurrencyType)dto.Index,
                MoneyTransfer = moneyDouble,
                OperationType = TypeOfOperation.refill
            };
            _context.HistoryTransfers.Add(historyTransfer);
        }

        public CashAccountBalanceDTO GetPersonMoney(Guid id)
        {
            var rub = _context.PersonMoneys.FirstOrDefault(p => p.PersonId == id && p.Type == CurrencyType.RUB);
            var usd = _context.PersonMoneys.FirstOrDefault(p => p.PersonId == id && p.Type == CurrencyType.USD);
            var eur = _context.PersonMoneys.FirstOrDefault(p => p.PersonId == id && p.Type == CurrencyType.EUR);

            var balance = new CashAccountBalanceDTO();

            if (rub != null)
            {
                balance.Rub = Math.Round((double)rub.Balance, 2);
            }

            if (usd != null)
            {
                balance.Usd = Math.Round((double)usd.Balance, 2);
            }

            if (eur != null)
            {
                balance.Eur = Math.Round((double)eur.Balance, 2);
            }

            return balance;
        }
  
        public ExchangeRateCBDTO GetExchangeRateCB()
        {
            var exchangeRateCB = new ExchangeRateCBDTO();

            var client = new WebClient();
            var xml = client.DownloadString("https://www.cbr-xml-daily.ru/daily.xml");
            var xdoc = XDocument.Parse(xml);
            var el = xdoc.Element("ValCurs").Elements("Valute");

            var dollarS = el.Where(x => x.Attribute("ID").Value == "R01235").Select(x => x.Element("Value").Value).FirstOrDefault();
            var dollar = new System.Globalization.CultureInfo("ru-Ru");
            exchangeRateCB.Usd = Convert.ToDouble(dollarS, dollar);

            var eurS = el.Where(x => x.Attribute("ID").Value == "R01239").Select(x => x.Element("Value").Value).FirstOrDefault();
            var euro = new System.Globalization.CultureInfo("ru-Ru");
            exchangeRateCB.Eur = Convert.ToDouble(eurS, euro);

            return exchangeRateCB;
        }
    }
}