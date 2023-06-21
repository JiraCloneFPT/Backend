using Microsoft.AspNetCore.Mvc;
using be.Models;
using be.Services.ProductService;
using be.DTOs;

namespace be.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : Controller
    {
        public readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("GetAllProduct")]
        public ActionResult GetProductList()
        {
            try
            {
                var productList = _productService.GetAllProduct();
                return Ok(productList);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("GetAllProductName")]
        public ActionResult GetProductNameList()
        {
            try
            {
                var productNameList = _productService.GetAllProductName();
                return Ok(productNameList);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("AddProduct")]
        public async Task<ActionResult> AddProduct(ProductInformation addProduct)
        {
            try
            {
                Product productInformation = new Product();
                productInformation.ProductName = addProduct.ProductName;
                productInformation.Status = addProduct.Status;
                var result = _productService.AddProduct(productInformation);
                return Ok(new
                {
                    message = "Add product success!",
                    status = 200,
                    data = result
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("GetProductDetail")]
        public ActionResult GetComponentDetail(int productId)
        {
            try
            {
                var product = _productService.GetProductInformation(productId);
                if (product == null)
                {
                    return Ok(new
                    {
                        message = "The product doesn't exist in database!",
                        status = 400
                    });
                }
                else
                {
                    return Ok(product);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("UpdateProduct/{id}")]
        public ActionResult UpdateProject([FromBody] ProductInformation product)
        {
            try
            {
                Product updateProduct = new Product();
                updateProduct.ProductId = product.ProductId;
                updateProduct.ProductName = product.ProductName;
                updateProduct.Status = product.Status;
                _productService.UpdateProduct(updateProduct);
                var result = _productService.GetProductInformation(product.ProductId);
                return Ok(new
                {
                    message = "Edit product success!",
                    status = 200,
                    data = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("ChangeProductStatus")]
        public ActionResult ChangeStatus(int productId, bool status)
        {
            try
            {
                var check = _productService.GetProductInformation(productId);
                if (check == null)
                {
                    return Ok(new
                    {
                        message = "The product doesn't exist in database!",
                        status = 400
                    });
                }
                else
                {
                    check.Status = status;
                    _productService.ChangeStatus(check);
                    return Ok(new
                    {
                        message = "Edit product success!",
                        status = 200,
                        data = _productService.GetProductInformation(productId)
                    });
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
