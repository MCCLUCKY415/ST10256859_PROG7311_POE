using System.ComponentModel.DataAnnotations;

namespace ST10256859_PROG7311_POE.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please enter a valid email address.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
