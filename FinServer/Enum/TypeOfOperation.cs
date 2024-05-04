namespace FinServer.Enum
{
    public enum TypeOfOperation
    {
        refill = 0,
        moneyTransfer = 1,
        exchange = 2,
    }

    public static class TypeOperation
    {
        public static string GetTypeOfOperation(TypeOfOperation type)
        {
            return type switch
            {
                TypeOfOperation.refill => "Пополнение",
                TypeOfOperation.moneyTransfer => "Перевод денег",
                TypeOfOperation.exchange => "Обмен",

                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}
