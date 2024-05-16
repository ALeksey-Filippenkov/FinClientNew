using System.ComponentModel.DataAnnotations;

namespace FinancialApp.DataBase.DbModels
{
    /// <summary>
    /// Данные администратора
    /// </summary>
    public class DbAdmin
    {
        /// <summary>
        /// Уникальный Id администратора
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Имя администратора
        /// </summary>
        [StringLength(100)]
        public string? Name { get; set; } = "Супер пупер";

        /// <summary>
        /// Фамилия администратора
        /// </summary>
        [StringLength(100)]
        public string? Surname { get; set; } = "Администратор!";

        /// <summary>
        /// Логин администратора
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Пароль администратора
        /// </summary>
        public string Password { get; set; }
    }
}
