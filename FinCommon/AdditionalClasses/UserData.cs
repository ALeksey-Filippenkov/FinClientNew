using System.ComponentModel.DataAnnotations;

namespace FinCommon.AdditionalClasses
{
    public class UserData
    {
        /// <summary>
        /// Уникальный Id пользователя
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Возраст пользователя
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Город проживания пользователя
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Адресс проживания пользователя
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Номер телефона пользователя
        /// </summary>
        public int PhoneNumber { get; set; }

        /// <summary>
        /// Электронная почта пользователя
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// ЛОгин пользователя
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Статус пользователя: забанен или не забанен
        /// </summary>
        public bool IsBanned { get; set; }
    }
}
