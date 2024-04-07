namespace FinCommon.DTO
{
    public class ValidationMoneyReplenishmentDTO
    {
        /// <summary>
        /// Код ошибки валидации данных
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// Описание ошибки валидации данных
        /// </summary>
        public Dictionary<string, List<string>> Errors { get; set; }

        /// <summary>
        /// Результат поплнения денег на счет
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// СОобщение о результате пополнения денег на счет
        /// </summary>
        public string Message { get; set; }

    }
}
