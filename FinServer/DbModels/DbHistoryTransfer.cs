namespace FinServer.DbModels
{
    public class DbHistoryTransfer
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey(nameof(SenderId))]
        public virtual Guid? SenderId { get; set; }

        [ForeignKey("SenderId")]
        public virtual DbPerson? Sender { get; set; }

        [ForeignKey(nameof(RecipientId))]
        public virtual Guid? RecipientId { get; set; }

        [ForeignKey("RecipientId")]
        public virtual DbPerson? Recipient { get; set; }

        public CurrencyType Type { get; set; }

        public double MoneyTransfer { get; set; }

        public DateTime DateTime { get; set; }

        public TypeOfOperation OperationType { get; set; }
    }
}
