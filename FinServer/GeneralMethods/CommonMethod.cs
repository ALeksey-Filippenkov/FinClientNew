using Microsoft.VisualBasic;

namespace FinServer.GeneralMethods
{
    public class CommonMethod
    {
        public static DbPersonMoney GetSearchAccountOwner(MoneyAccountDetailsDTO dto, ApplicationContext context)
        {
            return context.PersonMoneys.FirstOrDefault(m => m.Type == (CurrencyType)dto.Index && m.PersonId == dto.PersonId);
        }

        public static List<DbHistoryTransfer> GetHistoryTransfer(Guid id, ApplicationContext context)
        {
            return context.HistoryTransfers.Where(h => h.SenderId == id || h.RecipientId == id).ToList();
        }
    }
}
