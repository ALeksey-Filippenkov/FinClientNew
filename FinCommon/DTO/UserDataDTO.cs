using System.ComponentModel.DataAnnotations;

namespace FinCommon.DTO
{
    public class UserDataDTO
    {
        /// <summary>
        /// Уникальный ID пользователя
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Имя не может быть меньше 3 букв")]
        public string Name { get; set; }

        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Фамилия не может быть меньше 3 букв")]
        public string Surname { get; set; }

        /// <summary>
        /// Возраст пользователя
        /// </summary>
        [Range(0, 200, ErrorMessage = "Возраст не может быть меньше 0 и больше 200 лет")]
        public int Age { get; set; }

        /// <summary>
        /// Город проживания пользователя
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Адрес проживания пользователя
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Номер телефона пользователя
        /// </summary>
        //[Phone(ErrorMessage = "Номер телефона введен не корректно")]
        public int PhoneNumber { get; set; }

        /// <summary>
        /// Электронный адрес пользователя
        /// </summary>
        //[RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес электронной почты")]
        //[EmailAddress(ErrorMessage = "Адрес элетронной почты введен не корректно")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Логин пользователя
        /// </summary>
        [Required(ErrorMessage = "Логин не может быть пустым")]
        public string Login { get; set; }

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        [Required(ErrorMessage = "Пароль не может быть пустым")]
        public string Password { get; set; }

        /// <summary>
        /// Статус пользователя (Забанен, не забанен)
        /// </summary>
        public bool? IsBanned { get; set; }
    }
}
