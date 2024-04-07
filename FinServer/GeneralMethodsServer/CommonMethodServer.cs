using FinServer.DbModels;
using FinServer.Enum;

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
    }
}
