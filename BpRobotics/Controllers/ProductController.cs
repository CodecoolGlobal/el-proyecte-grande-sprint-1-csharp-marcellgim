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

        [HttpGet("{id}", Name = "GetProductById")]
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
        public ActionResult CreateProduct([FromBody] Product newProduct)
        {
            try
            {
                _productRepository.Add(newProduct);
                return CreatedAtRoute("GetProductById", new { id = newProduct.ID }, newProduct);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}