using System.ComponentModel.DataAnnotations;

namespace FinCommon.DTO
{
    public class MoneyAccountDetailsDTO
    {
        /// <summary>
        /// Уникаьлный ID пользователя
        /// </summary>
        public Guid PersonId { get; set; }

        /// <summary>
        /// Индекс выбранного типа валюты
        /// </summary>
        public int Index { get; set; }
        
        /// <summary>
        /// Сумма пополнения счета
        /// </summary>
        [Required(ErrorMessage = @"Вы не ввели сумму для пополнения")]
        [Range(1, int.MaxValue, ErrorMessage = "Пополнение не может быть меньше 1")]
        public string Balance { get; set; }
    }
}
