using be.Models;
using Microsoft.EntityFrameworkCore;

namespace be.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DbJiraCloneContext _context;

        public ProductRepository()
        {
            _context = new DbJiraCloneContext();
        }
        public object AddProduct(Product product)
        {
            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return product;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public void ChangeStatus(Product product)
        {
            try
            {
                var updateStatusProduct = _context.Products.SingleOrDefault(x => x.ProductId == product.ProductId);
                updateStatusProduct.Status = product.Status;
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

        }

        public IList<Product> GetAllProduct()
        {
            return _context.Products.ToList();
        }

        public IList<string> GetAllProductName()
        {
            var productNames = (from product in _context.Products
                                select product.ProductName).ToList();
            return productNames;
        }

        public Product GetProductInformation(int productId)
        {
            try
            {
                var productDetail = _context.Products.SingleOrDefault(x => x.ProductId == productId);
                return productDetail;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public Product UpdateProduct(Product product)
        {
            try
            {
                var updateProduct = _context.Products.SingleOrDefault(x => x.ProductId == product.ProductId);
                updateProduct.ProductName = product.ProductName;
                _context.SaveChanges();
                return updateProduct;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
    }
}
