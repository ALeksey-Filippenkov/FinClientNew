using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FinServer.Enum;

namespace FinServer.DbModels
{
    public class DbHistoryTransfer
    {
        /// <summary>
        /// Уникальный ID финансовой операции пользователя
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Уникальный ID отправителя денежных средств
        /// </summary>
        [ForeignKey(nameof(SenderId))]
        public virtual Guid? SenderId { get; set; }

        [ForeignKey("SenderId")]
        public virtual DbPerson? Sender { get; set; }

        /// <summary>
        /// Уникальный ID получателя денежных средств
        /// </summary>

        [ForeignKey(nameof(RecipientId))]
        public virtual Guid? RecipientId { get; set; }

        [ForeignKey("RecipientId")]
        public virtual DbPerson? Recipient { get; set; }

        /// <summary>
        /// Тип валюты
        /// </summary>
        public CurrencyType Type { get; set; }

        /// <summary>
        /// Кол-во денег отправленных
        /// </summary>
        public double MoneyTransfer { get; set; }

        /// <summary>
        /// Дата создания операции
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Тип операции: пополнение баланся, обмен или перевод другому лицу
        /// </summary>
        public TypeOfOperation OperationType { get; set; }
    }
}
