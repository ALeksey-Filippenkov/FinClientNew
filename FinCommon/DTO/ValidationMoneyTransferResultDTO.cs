namespace FinCommon.DTO
{
    public class ValidationMoneyTransferResultDTO
    {
        /// <summary>
        /// Код ошибки валидации данных
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// Сообщение ошибки валидации данных
        /// </summary>
        public Dictionary<string, List<string>> Errors { get; set; }

        /// <summary>
        /// Результат перевода денег
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Сообщение о результате перевода денег
        /// </summary>
        public Dictionary<string, string> Message { get; set; }
    }
}
