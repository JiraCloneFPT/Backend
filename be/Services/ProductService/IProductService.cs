using be.Models;

namespace be.Services.ProductService
{
    public interface IProductService
    {
        object AddProduct(Product product);
        IList<Product> GetAllProduct();
        void ChangeStatus(Product product);
        Product UpdateProduct(Product product);

        Product GetProductInformation(int productId);

        IList<string> GetAllProductName();
    }
}
