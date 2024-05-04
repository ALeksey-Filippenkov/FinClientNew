using FinServer.DbModels;
using FinServer.Enum;

namespace FinServer.GeneralClass
{
    public class FinancialTransactionData
    {
        /// <summary>
        /// Уникальный Id отправителя денег
        /// </summary>
        public Guid SenderId { get; set; }

        /// <summary>
        /// Уникальный ID получателя денег
        /// </summary>
        public Guid RecipientId { get; set; }

        /// <summary>
        /// Количество денег
        /// </summary>
        public double Money { get; set; }

        /// <summary>
        /// Индекс валюты счета
        /// </summary>
        public int CurrencyIndex { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ApplicationContext Context { get; set; }

        /// <summary>
        /// Тип операций с деньгами (пополнение, обмен, перевод)
        /// </summary>
        public TypeOfOperation TypeOfOperationWithMoney { get; set; }
    }
}
