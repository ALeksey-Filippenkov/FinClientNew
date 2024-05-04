﻿namespace FinCommon.DTO
{
    public class UserDataAccountInformationDTO
    {
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
        /// Адрес проживания пользователя
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Номер телефона пользователя
        /// </summary>
        public int PhoneNumber { get; set; }

        /// <summary>
        /// Эллектронная почта пользователя
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
    }
}
