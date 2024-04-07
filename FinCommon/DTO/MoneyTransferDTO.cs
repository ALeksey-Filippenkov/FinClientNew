using System.ComponentModel.DataAnnotations;

namespace FinCommon.DTO
{
    public class MoneyTransferDTO
    {
        /// <summary>
        /// Уникальный ID пользователя
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Номер телефона получателя денежных средств
        /// </summary>
        [Required (ErrorMessage = "Вы не ввели номер телефона")]
        public int RecipientsPhoneNumber { get; set; }

        /// <summary>
        /// Индекс типа денежных средств
        /// </summary>
        [Required(ErrorMessage = "Вы не выбрали тип валюты")]
        public int Index { get; set; }

        /// <summary>
        /// Сумма отправления
        /// </summary>
        [Required (ErrorMessage = "Вы не ввели сумму для перевода")]
        public double MoneyTransfer { get; set; }
    }
}
