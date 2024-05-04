namespace FinCommon.DTO
{
    public class ValidationCreatingMoneyAccountDTO
    {
        /// <summary>
        /// Результат открытия финансового счета пользователя
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Сообщение о результате открытия финансового счета пользователя
        /// </summary>
        public string Message { get; set; }
    }
}
