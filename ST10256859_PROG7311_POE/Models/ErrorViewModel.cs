// Dhiren Ruthenavelu
// ST10256859
// Group 2

// References:
// - GitHub Copilot for assisting with the structure of the code.
// - ChatGPT for assisting me with finding and fixing errors in the code.

namespace ST10256859_PROG7311_POE.Models
{
    // ViewModel for displaying error information
    public class ErrorViewModel
    {
        // The unique request ID for the current error
        public string? RequestId { get; set; }

        // Indicates whether the RequestId should be shown
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
