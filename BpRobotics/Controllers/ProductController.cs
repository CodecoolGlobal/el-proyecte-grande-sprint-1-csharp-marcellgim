using BpRobotics.Data.Entity;
using BpRobotics.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BpRobotics.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IRepository<Product> productRepository, IWebHostEnvironment hostEnvironment)
        {
            _productRepository = productRepository;
            _webHostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetAll()
        {
            return Ok(_productRepository.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            try
            {
                var product = _productRepository.Get(id);
                return Ok(product);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<Product> CreateProduct([FromForm] Product newProduct)
        {
            try
            {
                _productRepository.Add(newProduct);

                string filePath = Path.Combine(_webHostEnvironment.ContentRootPath, $"MyStaticFiles/images/{newProduct.Img}");
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    newProduct.ProductImage.CopyTo(fileStream);
                }

                return Ok(newProduct);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}