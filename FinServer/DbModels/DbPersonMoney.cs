using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FinServer.Enum;

namespace FinServer.DbModels
{
    public class DbPersonMoney
    {
        /// <summary>
        /// Уникальный ID финансового счетапользователя
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Уникальный ID владельца финансового счета
        /// </summary>
        [ForeignKey(nameof(Person))]
        public Guid? PersonId { get; set; }
        public DbPerson Person { get; set; }

        /// <summary>
        /// Тип валюты финансового счета
        /// </summary>
        public CurrencyType Type { get; set; }
        
        /// <summary>
        /// Баланс денег на счете
        /// </summary>
        public double? Balance { get; set; } = 0;
    }
}
