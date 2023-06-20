namespace Practical_11.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
        public int ErrorCode { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}