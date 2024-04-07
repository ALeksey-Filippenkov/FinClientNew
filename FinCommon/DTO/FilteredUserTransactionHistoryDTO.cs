using FinServer.AdditionalClasses;

namespace FinCommon.DTO
{
    public class FilteredUserTransactionHistoryDTO
    {
        public bool IsSuccess { get; set; }

        public Dictionary<string, string> Message { get; set; }

        public List<HistoryMoneyTransactions> HistoryTransfers { get; set; }
    }
}
