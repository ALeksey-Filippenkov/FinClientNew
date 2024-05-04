namespace FinCommon.DTO
{
    public class ExchangeRateCBDTO
    {
        /// <summary>
        /// Официальный курс доллара США взятый с официального сайта ЦБ РФ
        /// </summary>
        public double Usd { get; set; }

        /// <summary>
        /// Оффициальный курс Евро взятый с официального сайта ЦБ РФ
        /// </summary>
        public double Eur { get; set; }
    }
}
