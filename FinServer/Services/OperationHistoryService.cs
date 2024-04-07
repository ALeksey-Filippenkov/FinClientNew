using FinCommon.DTO;
using FinServer.AdditionalClasses;
using FinServer.DbModels;
using FinServer.Enum;
using FinServer.GeneralMethodsServer;

namespace FinServer.Services
{
    public class OperationHistoryService
    {
        private readonly ApplicationContext _context;

        public OperationHistoryService()
        {
            _context = new ApplicationContext();
        }
        public TransferHistoryDataDTO GetHistoryTransfer(Guid id)
        {
            var historyTransfers = CommonMethodServer.GetHistoryTransfer(id, _context);

            var transferHistoryData = new TransferHistoryDataDTO
            {
                HistoryTransfers = new List<HistoryMoneyTransactions>()
            };

            foreach (var transferItem in historyTransfers)
            {
                var historyMoneyTransactions = new HistoryMoneyTransactions();

                historyMoneyTransactions.DateOperation = transferItem.DateTime;
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

        public FilteredUserTransactionHistoryDTO GetSearchOperationUserTransfer(SearchOperationDataDTO dto)
        {
            var historyTransfers = CommonMethodServer.GetHistoryTransfer(dto.Id, _context);

            var transferHistoryData = new FilteredUserTransactionHistoryDTO
            {
                HistoryTransfers = new List<HistoryMoneyTransactions>()
            };

            List<DbHistoryTransfer> result = null;

            if (historyTransfers.Count == 0)
            {
                return new FilteredUserTransactionHistoryDTO()
                {
                    IsSuccess = false,
                    Message = new Dictionary<string, string>() { {"OperationCountError", "У Вас еще небыло операций!" } }
                };
            }

            if (dto.CurrencyTypeValue != CurrencyType.RUB.ToString() && dto.CurrencyTypeValue != CurrencyType.USD.ToString() && dto.CurrencyTypeValue != CurrencyType.EUR.ToString() && dto.CurrencyTypeValue != string.Empty)
            {
                return new FilteredUserTransactionHistoryDTO()
                {
                    IsSuccess = false,
                    Message = new Dictionary<string, string>() { { "CurrencyTypeError", $"Операций с типом валюты {dto.CurrencyTypeValue} не найдены!" } }
                };
            }


            var searchPersonRecipientName = _context.Persons.FirstOrDefault(p => p.Name == dto.PersonRecipientName);

            if (dto.StartingDateSearch == dto.EndingDateSearch)
            {
                if (dto.CurrencyTypeValue != string.Empty && dto.PersonRecipientName != string.Empty)
                {
                    if (searchPersonRecipientName != null)
                    {
                        result = historyTransfers.Where(s => s.DateTime.Date == dto.StartingDateSearch &&
                                                             s.Type.ToString() == dto.CurrencyTypeValue
                                                             && s.RecipientId == searchPersonRecipientName.Id).ToList();
                    }
                }
                else if (dto.CurrencyTypeValue != string.Empty && dto.PersonRecipientName == string.Empty)
                {
                    result = historyTransfers.Where(s => s.DateTime.Date == dto.StartingDateSearch && s.Type.ToString() == dto.CurrencyTypeValue).ToList();
                }
                else if (dto.CurrencyTypeValue == string.Empty && dto.PersonRecipientName != string.Empty)
                {
                    if (searchPersonRecipientName != null)
                    {
                        result = historyTransfers.Where(s => s.DateTime.Date == dto.StartingDateSearch && s.RecipientId == searchPersonRecipientName.Id).ToList();
                    }
                }
                else
                {
                    result = historyTransfers.Where(s => s.DateTime.Date == dto.StartingDateSearch).ToList();
                }
            }
            else
            {
                if (dto.CurrencyTypeValue != string.Empty && dto.PersonRecipientName != string.Empty)
                {
                    result = historyTransfers.Where(s => s.DateTime.Date >= dto.StartingDateSearch && s.DateTime <= dto.EndingDateSearch
                                                                                            && s.Type.ToString() == dto.CurrencyTypeValue
                                                                                            && s.RecipientId == searchPersonRecipientName.Id).ToList();
                }
                else if (dto.CurrencyTypeValue != string.Empty && dto.PersonRecipientName == string.Empty)
                {
                    result = historyTransfers.Where(s => s.DateTime.Date >= dto.StartingDateSearch && s.DateTime <= dto.EndingDateSearch
                                                                                            && s.Type.ToString() == dto.CurrencyTypeValue).ToList();
                }
                else if (dto.CurrencyTypeValue == string.Empty && dto.PersonRecipientName != string.Empty)
                {
                    if (searchPersonRecipientName != null)
                    {
                        result = historyTransfers.Where(s => s.DateTime.Date >= dto.StartingDateSearch && s.DateTime <= dto.EndingDateSearch
                                                                                                && s.RecipientId == searchPersonRecipientName.Id).ToList();
                    }
                }
                else
                {
                    result = historyTransfers.Where(s => s.DateTime.Date >= dto.StartingDateSearch && s.DateTime <= dto.EndingDateSearch).ToList();
                }
            }

            if (result == null)
            {
                return new FilteredUserTransactionHistoryDTO()
                {
                    IsSuccess = false,
                    Message = new Dictionary<string, string>(){{ "OperationsByNameError", $"Операций с пользователем {dto.PersonRecipientName} не найдены!" } }
                };
            }

            if (result.Count == 0)
            {
                return new FilteredUserTransactionHistoryDTO()
                {
                    IsSuccess = false,
                    Message = new Dictionary<string, string>() { { "OperationsByDateError", $"{DateOnly.FromDateTime(dto.StartingDateSearch)} небыло произведено операций!"}}
                    };
            }

            foreach (var transferItem in result)
            {
                var historyMoneyTransactions = new HistoryMoneyTransactions();

                historyMoneyTransactions.DateOperation = transferItem.DateTime;
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

    }
}