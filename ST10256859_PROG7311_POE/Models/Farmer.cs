namespace ST10256859_PROG7311_POE.Models
{
    public class Farmer
    {
        public int FarmerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
