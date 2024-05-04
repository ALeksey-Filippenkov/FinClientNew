namespace FinCommon.DTO
{
    public class MoneyExchangeDTO
    {
        /// <summary>
        /// Уникальный ID пользователя
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Индекс счета для списания денежных средств
        /// </summary>
        public int DebitAccountIndex { get; set; }

        /// <summary>
        /// Индекс денежного счета для зачислений денежных средств
        /// </summary>
        public int AccountForReplenishmentIndex { get; set; }

        /// <summary>
        /// Количество денег для обмена
        /// </summary>
        public double Money { get; set; }
    }
}
