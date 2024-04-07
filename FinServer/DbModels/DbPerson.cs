using System.ComponentModel.DataAnnotations;

namespace FinServer.DbModels
{
    public class DbPerson
    {
        /// <summary>
        /// Ключ
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        [StringLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        [StringLength(100)]
        public string Surname { get; set; }

        /// <summary>
        /// Возраст пользователя
        /// </summary>
        [MaxLength(200)]
        public int Age { get; set; }

        /// <summary>
        /// Город проживания пользователя
        /// </summary>
        [StringLength(100)]
        public string City { get; set; }

        /// <summary>
        /// Адресс проживания пользователя
        /// </summary>
        [StringLength(500)]
        public string Address { get; set; }

        /// <summary>
        /// Номер телефона пользователя
        /// </summary>
        [MaxLength(20)]
        public int PhoneNumber { get; set; }

        /// <summary>
        /// Электронная почта пользователя
        /// </summary>
        [StringLength(100)]
        public string EmailAddress { get; set; }

        /// <summary>
        /// ЛОгин пользователя
        /// </summary>
        [StringLength(100)]
        public string Login { get; set; }

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        [StringLength(100)]
        public string Password { get; set; }

        /// <summary>
        /// Статус пользователя: забанен или не забанен
        /// </summary>
        public bool IsBanned { get; set; }

        /// <summary>
        /// Финансовые счета пользователей
        /// </summary>
        public List<DbPersonMoney>? PersonMoneys { get; set; }

    }
}
