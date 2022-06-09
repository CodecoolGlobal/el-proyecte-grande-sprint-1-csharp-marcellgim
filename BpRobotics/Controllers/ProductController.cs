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
        public ProductController(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
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
        public ActionResult<Product> CreateProduct([FromBody] Product newProduct)
        {
            try
            {
                _productRepository.Add(newProduct);
                return Ok(newProduct);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}