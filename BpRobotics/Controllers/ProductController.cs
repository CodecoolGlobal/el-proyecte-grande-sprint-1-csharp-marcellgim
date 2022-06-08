using BpRobotics.Data.Model;
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
        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }
    }
}