namespace ST10256859_PROG7311_POE.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public decimal ProductPrice { get; set; }          
        public int AvailableQuantity { get; set; }
        public string? Description { get; set; }
        public DateTime ProductionDate { get; set; }
        public byte[]? ProductImage { get; set; }

        public int FarmerID { get; set; }
        public Farmer Farmer { get; set; }
    }
}
