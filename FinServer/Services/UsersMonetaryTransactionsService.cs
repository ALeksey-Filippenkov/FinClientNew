using FinCommon.DTO;
using FinServer.DbModels;
using FinServer.Enum;
using FinServer.GeneralMethodsServer;

namespace FinServer.Services
{
    public class UsersMonetaryTransactionsService
    {
        private readonly ApplicationContext _context;

        public UsersMonetaryTransactionsService()
        {
            _context = new ApplicationContext();
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
            SavingTheTranslationHistory(dto, personRecipient);
            _context.SaveChanges();
            return new ValidationMoneyTransferResultDTO()
            {
                IsSuccess = true,
                Message = new Dictionary<string, string>
                    { { "Congratulation", "Поздравляем! Вы успешно перевели деньги" } }
            };
        }

        private void SavingTheTranslationHistory(MoneyTransferDTO dto, DbPerson personRecipient)
        {
            var historyTransfer = new DbHistoryTransfer
            {
                Id = Guid.NewGuid(),
                DateTime = DateTime.Now,
                SenderId = dto.Id,
                Type = (CurrencyType)dto.Index,
                RecipientId = personRecipient.Id,
                MoneyTransfer = dto.MoneyTransfer,
                OperationType = TypeOfOperation.moneyTransfer
            };
            _context.HistoryTransfers.Add(historyTransfer);
        }
    }
}
