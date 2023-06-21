using be.Models;
using be.Repositories.ProductRepository;

namespace be.Services.ProductService
{
    public class ProductService : IProductService
    {
        public IProductRepository _productRepo;

        public ProductService(IProductRepository productRepository)
        {
            _productRepo = productRepository;
        }
        public object AddProduct(Product product)
        {
            _productRepo.AddProduct(product);
            return product;
        }

        public void ChangeStatus(Product product)
        {
            _productRepo.ChangeStatus(product);
        }

        public IList<Product> GetAllProduct()
        {
            return _productRepo.GetAllProduct().ToList();
        }

        public IList<string> GetAllProductName()
        {
            return _productRepo.GetAllProductName().ToList();
        }

        public Product GetProductInformation(int productId)
        {
            return _productRepo.GetProductInformation(productId);
        }

        public Product UpdateProduct(Product product)
        {
            _productRepo.UpdateProduct(product);
            Product updateProduct = _productRepo.GetProductInformation(product.ProductId);
            return updateProduct;
        }
    }
}
