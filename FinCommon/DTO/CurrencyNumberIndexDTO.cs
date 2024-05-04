namespace FinCommon.DTO
{
    public class CurrencyNumberIndexDTO
    {
        /// <summary>
        /// Уникальный Id пользователя
        /// </summary>
        public Guid PersonId { get; set; }

        /// <summary>
        /// Индекс выбранного типа валюты
        /// </summary>
        public int Index { get; set; }
    }
}
