namespace FinCommon.DTO
{
    public class ValidationMoneyReplenishmentDTO
    {
        public int Status { get; set; }

        public Dictionary<string, List<string>> Errors { get; set; }

        public bool IsSuccess { get; set; }
        public string Message { get; set; }

    }
}
