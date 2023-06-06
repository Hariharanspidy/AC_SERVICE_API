namespace AC_Service_API.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string productName { get; set; }
        public string ProductModelNo { get; set; }
        public DateTime ProductDateOfPurchase { get; set;}
        public string contactNumber { get; set;}
        public string problemDescription { get; set; }
        public string availableSlots { get; set;}

    }
}
