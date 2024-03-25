namespace FinCommon.Models
{
    internal class ValidationResult
    {
        public int Status { get; set; }

        public Dictionary<string, List<string>> Errors { get; set; }
    }
}
