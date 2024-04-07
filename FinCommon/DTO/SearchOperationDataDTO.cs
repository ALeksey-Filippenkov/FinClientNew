namespace FinCommon.DTO
{
    public class SearchOperationDataDTO
    {
        /// <summary>
        /// Уникальный Id пользователя
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Начальная дата поиска
        /// </summary>
        public DateTime StartingDateSearch { get; set; }

        /// <summary>
        /// Конечная дата поиска
        /// </summary>
        public DateTime EndingDateSearch { get; set; }

        /// <summary>
        /// Валюта финансововй операции
        /// </summary>
        public string CurrencyTypeValue { get; set; }

        /// <summary>
        /// Имя отправителя
        /// </summary>
        public string PersonRecipientName { get; set; }


    }
}
