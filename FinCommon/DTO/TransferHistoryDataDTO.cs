using FinServer.AdditionalClasses;

namespace FinCommon.DTO
{
    public class TransferHistoryDataDTO
    {
        /// <summary>
        /// Результат поиска финансовых операций пользователя
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Текст ошибки о поиске финансовых операций пользователя
        /// </summary>
        public Dictionary<string, string> Message { get; set; }

        /// <summary>
        /// Список финансовых операций пользователя
        /// </summary>
        public List<HistoryMoneyTransactions> HistoryTransfers { get; set; }
    }
}
