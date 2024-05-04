namespace FinCommon.DTO
{
    public class ValidationRegistrationResultDTO
    {
        /// <summary>
        /// Номер ошибки валидации данных
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// Описание ошибки при валидациии  данных
        /// </summary>
        public Dictionary<string, List<string>> Errors { get; set; }

        /// <summary>
        /// Результат проверки данных на соответсвие требованиям
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Сообщение об обшике или успешной регистрации пользователя
        /// </summary>
        public Dictionary<string, string> Message { get; set; }
    }
}
