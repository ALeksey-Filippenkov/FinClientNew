namespace FinCommon.DTO
{
    public class ValidationAuthorizationResultDTO
    {
        public int Status { get; set; }

        public Dictionary<string, List<string>> Errors { get; set; }

        public bool IsSuccess { get; set; }

        public Dictionary<string, string> Message { get; set; }

        public Guid idAccount { get; set; }
    }
}
