using FinCommon.DTO;
using FinServer.DbModels;
using FinServer.Enum;
using FinServer.GeneralClass;
using FinServer.GeneralMethodsServer;
using System.Net;
using System.Xml.Linq;

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

            var dollar = el.Where(x => x.Attribute("ID").Value == "R01235").Select(x => x.Element("Value").Value).FirstOrDefault();
            var usd = new System.Globalization.CultureInfo("ru-Ru");
            exchangeRateCB.Usd = Convert.ToDouble(dollar, usd);

            var euro = el.Where(x => x.Attribute("ID").Value == "R01239").Select(x => x.Element("Value").Value).FirstOrDefault();
            var eur = new System.Globalization.CultureInfo("ru-Ru");
            exchangeRateCB.Eur = Convert.ToDouble(euro, eur);

            return exchangeRateCB;
        }

        public ValidationMoneyTransferResultDTO TransferMoneyAnotherUser(MoneyTransferDTO dto)
        {
            if (dto.MoneyTransfer < 0)
            {
                return new ValidationMoneyTransferResultDTO()
                {
                    IsSuccess = false,
                    Message = new Dictionary<string, string>() { { "MoneyTransferError", "Внесение денег не может быть меньше 0" } }
                };
            }

            if (dto.Index == -1)
            {
                return new ValidationMoneyTransferResultDTO()
                {
                    IsSuccess = false,
                    Message = new Dictionary<string, string>() { { "CurrencyTypeError", "Вы не выбрали счет, с которого хотите осуществить перевод." } }
                };
            }
            var sendersMoneyAccount = CommonMethodServer.GetSearchAccountOwner(dto.Index, dto.Id, _context);

            if (sendersMoneyAccount == null)
            {
                return new ValidationMoneyTransferResultDTO()
                {
                    IsSuccess = false,
                    Message = new Dictionary<string, string>() { { "PersonSenderError", "У Вас нет счета с таким типом валюты" } }
                };
            }
            var personRecipient = _context.Persons.FirstOrDefault(p => p.PhoneNumber == dto.RecipientsPhoneNumber);
            if (personRecipient == null)
            {
                return new ValidationMoneyTransferResultDTO()
                {
                    IsSuccess = false,
                    Message = new Dictionary<string, string>() { { "PersonRecipientError", "Пользователь с таким номером телефона не найден" } }
                };
            }

            if (sendersMoneyAccount.Balance - dto.MoneyTransfer < 0)
            {
                return new ValidationMoneyTransferResultDTO()
                {
                    IsSuccess = false,
                    Message = new Dictionary<string, string>() { { "LackMoneyAccountError", "Недостаточно денег на счету" } }
                };
            }

            var recipientsCashAccount = CommonMethodServer.GetSearchAccountOwner(dto.Index, personRecipient.Id, _context);


            recipientsCashAccount.Balance += dto.MoneyTransfer;
            sendersMoneyAccount.Balance -= dto.MoneyTransfer;

            _context.SaveChanges();

            var financialTransactionData = new FinancialTransactionData()
            {
                SenderId = dto.Id,
                RecipientId = personRecipient.Id,
                Money = dto.MoneyTransfer,
                CurrencyIndex = dto.Index,
                Context = _context,
                TypeOfOperationWithMoney = TypeOfOperation.moneyTransfer
            };

            CommonMethodServer.SavingTheTranslationHistory(financialTransactionData);

            return new ValidationMoneyTransferResultDTO()
            {
                IsSuccess = true,
                Message = new Dictionary<string, string>
                    { { "Congratulation", "Поздравляем! Вы успешно перевели деньги" } }
            };
        }
        public ValidationMoneyExchangeResultDTO ExchangeMoneyUser(MoneyExchangeDTO dto)
        {
            if (dto.DebitAccountIndex == -1)
            {
                return new ValidationMoneyExchangeResultDTO()
                {
                    IsSuccess = false,
                    Message = new Dictionary<string, string>()
                    {
                        {
                            "The currency type for debiting is not selected",
                            $"Вы не выбрали тип валюты."
                        }
                    }
                };
            }

            if (dto.AccountForReplenishmentIndex == -1)
            {
                return new ValidationMoneyExchangeResultDTO()
                {
                    IsSuccess = false,
                    Message = new Dictionary<string, string>()
                    {
                        {
                            "The type of currency to deposit is not selected",
                            $"Вы не выбрали тип валюты."
                        }
                    }
                };
            }

            var debitAccount = CommonMethodServer.GetSearchAccountOwner(dto.DebitAccountIndex, dto.Id, _context);
            var replenishmentAccount = CommonMethodServer.GetSearchAccountOwner(dto.AccountForReplenishmentIndex, dto.Id, _context);

            if (debitAccount == null)
            {
                return new ValidationMoneyExchangeResultDTO()
                {
                    IsSuccess = false,
                    Message = new Dictionary<string, string>()
                    {
                        {
                            "DebitAccount",
                            $"У вас нет счета с которого вы хотите произвести {TypeOperation.GetTypeOfOperation(TypeOfOperation.exchange)}."
                        }
                    }
                };
            }

            if (replenishmentAccount == null)
            {
                return new ValidationMoneyExchangeResultDTO()
                {
                    IsSuccess = false,
                    Message = new Dictionary<string, string>()
                    {
                        {
                            "AccountForReplenishment",
                            $"У вас нет счета с которого вы хотите произвести {TypeOperation.GetTypeOfOperation(TypeOfOperation.exchange)}."
                        }
                    }
                };
            }

            if (debitAccount.Balance == 0 || debitAccount.Balance - dto.Money <= 0)
            {
                return new ValidationMoneyExchangeResultDTO()
                {
                    IsSuccess = false,
                    Message = new Dictionary<string, string>()
                    {
                        {
                            "MoneyError",
                            $"У вас недостаточно срадств на счету с которого вы хотите произвести {TypeOperation.GetTypeOfOperation(TypeOfOperation.exchange)}и!."
                        }
                    }
                };
            }

            if (dto.DebitAccountIndex == dto.AccountForReplenishmentIndex)
            {
                return new ValidationMoneyExchangeResultDTO()
                {
                    IsSuccess = false,
                    Message = new Dictionary<string, string>()
                    {
                        {
                            "ExchangeError",
                            "Для попоплнения счета перейдите в соответствующий раздел."
                        }
                    }
                };
            }

            debitAccount.Balance -= dto.Money;

            var course =  GetExchangeRateCB();

            switch ((CurrencyType)dto.DebitAccountIndex)
            {
                case CurrencyType.RUB when replenishmentAccount.Type == CurrencyType.USD:
                    replenishmentAccount.Balance += Math.Round(dto.Money / course.Usd, 2);
                    break;
                case CurrencyType.RUB when replenishmentAccount.Type == CurrencyType.EUR:
                    replenishmentAccount.Balance += Math.Round(dto.Money / course.Eur, 2);
                    break;
                case CurrencyType.USD when replenishmentAccount.Type == CurrencyType.RUB:
                    replenishmentAccount.Balance += Math.Round(dto.Money * course.Usd, 2);
                    break;
                case CurrencyType.USD when replenishmentAccount.Type == CurrencyType.EUR:
                    replenishmentAccount.Balance += Math.Round(dto.Money / course.Usd, 2);
                    break;
                case CurrencyType.EUR when replenishmentAccount.Type == CurrencyType.RUB:
                    replenishmentAccount.Balance += Math.Round(dto.Money * course.Eur, 2);
                    break;
                case CurrencyType.EUR when replenishmentAccount.Type == CurrencyType.USD:
                    replenishmentAccount.Balance += Math.Round(dto.Money / course.Usd, 2);
                    break;
            }

            _context.SaveChanges();

            var financialTransactionData = new FinancialTransactionData()
            {
                SenderId = dto.Id,
                RecipientId = dto.Id,
                Money = dto.Money,
                CurrencyIndex = dto.AccountForReplenishmentIndex,
                Context = _context,
                TypeOfOperationWithMoney = TypeOfOperation.exchange
            };

            CommonMethodServer.SavingTheTranslationHistory(financialTransactionData);
            
            return new ValidationMoneyExchangeResultDTO()
            {
                IsSuccess = true,
                Message = new Dictionary<string, string>
                    { { "Congratulation", "Поздравляем! Вы успешно обменяли деньги" } }
            };
        }
    }
}