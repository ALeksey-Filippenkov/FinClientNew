namespace FinServer.DbModels
{
    public class DbPersonMoney
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Person))]
        public Guid? PersonId { get; set; }
        public DbPerson Person { get; set; }

        public CurrencyType Type { get; set; }
        
        public double? Balance { get; set; } = 0;
    }
}
