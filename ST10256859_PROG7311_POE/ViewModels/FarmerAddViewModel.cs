// Dhiren Ruthenavelu
// ST10256859
// Group 2

// References:
// - GitHub Copilot for assisting with the structure of the code.
// - ChatGPT for assisting me with finding and fixing errors in the code.

using System.ComponentModel.DataAnnotations;

namespace ST10256859_PROG7311_POE.ViewModels
{
    // ViewModel for adding a new farmer
    public class FarmerAddViewModel
    {
        [Required(ErrorMessage = "Please enter farmer's first name.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }           // Farmer's first name

        [Required(ErrorMessage = "Please enter farmer's last name.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }            // Farmer's last name

        [Required(ErrorMessage = "Please enter farmer's email address.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [Display(Name = "Email")]
        public string Email { get; set; }               // Farmer's email address

        [Required(ErrorMessage = "Please enter farmer's phone number.")]
        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }         // Farmer's phone number

        [Required(ErrorMessage = "Please enter farmer's address.")]
        [Display(Name = "Address")]
        public string Address { get; set; }             // Farmer's address

        [Required(ErrorMessage = "Please create farmer's password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [RegularExpression(
            @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
            ErrorMessage = "Password must be at least 8 characters and include an uppercase letter, a lowercase letter, a number, and a special character."
        )]
        public string Password { get; set; }            // Farmer's password

        [Required(ErrorMessage = "Please confirm farmer's password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }     // Confirmation of the password
    }
}
