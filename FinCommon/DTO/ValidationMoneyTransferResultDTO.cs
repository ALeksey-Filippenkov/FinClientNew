namespace FinCommon.DTO
{
    public class ValidationMoneyTransferResultDTO
    {
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
