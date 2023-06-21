using be.Models;

namespace be.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        object AddProduct(Product product);
        IList<Product> GetAllProduct();
        void ChangeStatus(Product product);
        Product UpdateProduct(Product product);
        Product GetProductInformation(int productId);

        IList<string> GetAllProductName();
    }
}
