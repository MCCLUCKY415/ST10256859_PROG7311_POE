// Dhiren Ruthenavelu
// ST10256859
// Group 2

// References:
// - GitHub Copilot for assisting with the structure of the code.
// - ChatGPT for assisting me with finding and fixing errors in the code.

using System.ComponentModel.DataAnnotations;

namespace ST10256859_PROG7311_POE.ViewModels
{
    // ViewModel for user login
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please enter a valid email address.")]
        [Display(Name = "Email")]
        public string Email { get; set; }                   // User's email address

        [Required(ErrorMessage = "Please enter your password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }                // User's password
    }
}
