namespace FinCommon.DTO
{
    public class AuthorizationResultDTO
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
        /// Результат авторизации пользователя в личном кабинете
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Сообщение о результате авторизации пользователя в личном кабинете
        /// </summary>
        public Dictionary<string, string> Message { get; set; }

        /// <summary>
        /// Роль пользователя
        /// </summary>
        public string UserRole { get; set; }

        /// <summary>
        /// Уникальный ID пользователя
        /// </summary>
        public Guid IdAccount { get; set; }
    }
}
