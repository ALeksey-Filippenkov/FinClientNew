using FinServer.DbModels;
using FinServer.Enum;
using FinServer.GeneralClass;
using Microsoft.EntityFrameworkCore;

namespace FinServer.GeneralMethodsServer
{
    public class CommonMethodServer
    {
        public static DbPersonMoney GetSearchAccountOwner(int index, Guid id, ApplicationContext context)
        {
            return context.PersonMoneys.FirstOrDefault(m => m.Type == (CurrencyType)index && m.PersonId == id);
        }

        public static List<DbHistoryTransfer> GetHistoryTransfer(Guid id, ApplicationContext context)
        {
            return context.HistoryTransfers.Where(h => h.SenderId == id || h.RecipientId == id).ToList();
        }


        public static void SavingTheTranslationHistory(FinancialTransactionData financialTransactionData)
        {
            var historyTransfer = new DbHistoryTransfer
            {
                Id = Guid.NewGuid(),
                SenderId = financialTransactionData.SenderId,
                DateTime = DateTime.Now,
                Type = (CurrencyType)financialTransactionData.CurrencyIndex,
                MoneyTransfer = financialTransactionData.Money,
                RecipientId = financialTransactionData.RecipientId,
                OperationType = financialTransactionData.TypeOfOperationWithMoney
            };
            financialTransactionData.Context.HistoryTransfers.Add(historyTransfer);

            financialTransactionData.Context.SaveChanges();
        }
    }
}
