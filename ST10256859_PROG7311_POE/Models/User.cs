namespace ST10256859_PROG7311_POE.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // 'Farmer' or 'Employee'

        public int? FarmerID { get; set; }
        public Farmer Farmer { get; set; }

        public int? EmployeeID { get; set; }
        public Employee Employee { get; set; }
    }

}
