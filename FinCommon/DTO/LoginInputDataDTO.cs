using System.ComponentModel.DataAnnotations;

namespace FinCommon.DTO
{
    /// <summary>
    /// Модель для авторизации пользователя
    /// </summary>
    public class LoginInputDataDTO
    {
        /// <summary>
        /// Логин пользователя
        /// </summary>
        [Required(ErrorMessage = @"Логин не может быть пустым")]
        public string Login { get; set; }

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        [Required(ErrorMessage = @"Пароль не может быть пустым")]
        public string Password { get; set; }
    }
}
