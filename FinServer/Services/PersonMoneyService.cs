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

            var moneyAccount = CommonMethod.GetSearchAccountOwner(dto, _context);
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

        public ValidationMoneyReplenishmentDTO AddingMoneyToTheAccount(MoneyAccountDetailsDTO dto,
            DbPersonMoney moneyAccount,
            double moneyDouble)
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

        public void AddingMoneyToTheHistory(MoneyAccountDetailsDTO dto, double moneyDouble)
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

        public TransferHistoryDataDTO GetHistoryTransfer(Guid id)
        {
            var historyTransfers = CommonMethod.GetHistoryTransfer(id, _context);

            var transferHistoryData = new TransferHistoryDataDTO
            {
                HistoryTransfers = new List<HistoryMoneyTransactions>()
            };

            var historyMoneyTransactions = new HistoryMoneyTransactions();

            foreach (var transferItem in historyTransfers)
            {
                historyMoneyTransactions.DateOperation = DateOnly.FromDateTime(transferItem.DateTime);
                historyMoneyTransactions.CurrencyType = transferItem.Type.ToString();
                historyMoneyTransactions.Money = transferItem.MoneyTransfer;
                historyMoneyTransactions.TypeAction = TypeOperation.GetTypeOfOperation(transferItem.OperationType);

                var personSender = _context.Persons.First(p => p.Id == transferItem.SenderId);
                historyMoneyTransactions.SendersName = personSender.Name;

                if (transferItem.OperationType == TypeOfOperation.moneyTransfer)
                {
                    var personRecipient = _context.Persons.First(p => p.Id == transferItem.RecipientId);
                    historyMoneyTransactions.RecipientsName = personRecipient.Name;
                }

                transferHistoryData.HistoryTransfers.Add(historyMoneyTransactions);
            }
            return transferHistoryData;
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