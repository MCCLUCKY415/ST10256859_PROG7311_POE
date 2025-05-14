// Dhiren Ruthenavelu
// ST10256859
// Group 2

// References:
// - GitHub Copilot for assisting with the structure of the code.
// - ChatGPT for assisting me with finding and fixing errors in the code.

namespace ST10256859_PROG7311_POE.Models
{
    // Represents an employee in the system
    public class Employee
    {
        public int EmployeeID { get; set; }         // Unique identifier for the employee
        public string FirstName { get; set; }       // Employee's first name
        public string LastName { get; set; }        // Employee's last name
        public string PhoneNumber { get; set; }     // Employee's phone number
        public string Address { get; set; }         // Employee's address
        public string Email { get; set; }           // Employee's email address
        public string Password { get; set; }        // Employee's password
    }
}
