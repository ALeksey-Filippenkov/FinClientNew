namespace FinCommon.DTO
{
    public class CashAccountBalanceDTO
    {
        /// <summary>
        /// Баланс рублевого счета
        /// </summary>
        public double Rub { get; set; }

        /// <summary>
        /// Баланс счета в американских долларах
        /// </summary>
        public double Usd { get; set; }

        /// <summary>
        /// Баланс счета в евро
        /// </summary>
        public double Eur { get; set; }

    }
}
