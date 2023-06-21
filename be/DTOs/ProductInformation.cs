using be.Models;

namespace be.DTOs
{
    public class ProductInformation
    {
        public ProductInformation()
        {

        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public bool? Status { get; set; }
    }
}
