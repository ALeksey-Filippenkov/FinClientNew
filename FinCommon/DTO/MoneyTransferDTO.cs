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
        public int RecipientsPhoneNumber { get; set; }

        /// <summary>
        /// Индекс типа денежных средств
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Сумма отправления
        /// </summary>
        public double MoneyTransfer { get; set; }
    }
}
