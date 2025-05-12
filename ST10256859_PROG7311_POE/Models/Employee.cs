namespace ST10256859_PROG7311_POE.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }

        public ICollection<User> Users { get; set; }
    }

}
