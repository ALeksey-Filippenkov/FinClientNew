namespace FinServer.AdditionalClasses
{
    public class HistoryMoneyTransactions
    {
        public DateOnly DateOperation { get; set; }

        public string SendersName { get; set; }

        public string RecipientsName { get; set; }

        public string TypeAction { get; set; }

        public double Money { get; set; }

        public string CurrencyType { get; set; }
    }
}
