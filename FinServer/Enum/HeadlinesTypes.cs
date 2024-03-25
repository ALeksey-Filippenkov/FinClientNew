namespace FinServer.Enum
{
    public enum HeadlinesTypes
    {
        Date = 0,
        Sender = 1,
        TypeOfOperation = 2,
        CurrencyType = 3,
        Money = 4,
        Recipient = 5
    }

    public static class Headlines
    {
        public static string GetHeadlinesTypes(HeadlinesTypes type)
        {
            return type switch
            {
                HeadlinesTypes.Date => "Дата",
                HeadlinesTypes.Sender => "Отправитель",
                HeadlinesTypes.TypeOfOperation => "Тип операции",
                HeadlinesTypes.CurrencyType => "Тип валюты",
                HeadlinesTypes.Money => "Сумма",
                HeadlinesTypes.Recipient => "Получатель",
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}
