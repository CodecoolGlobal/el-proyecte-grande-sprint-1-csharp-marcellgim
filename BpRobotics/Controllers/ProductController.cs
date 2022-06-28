using BpRobotics.Core.Extensions;
using BpRobotics.Core.Model.ProductDTOs;
using BpRobotics.Data.Entity;
using BpRobotics.Data.Repositories;
using BpRobotics.Services;
using Microsoft.AspNetCore.Mvc;

namespace BpRobotics.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductViewDto>>> GetAll()
        {
            var products = await _productService.ListProducts();
            return products;
        }

        [HttpGet("{id}", Name = "GetProductById")]
        public async Task<ActionResult<ProductViewDto>> GetProductById(int id)
        {
            try
            {
                return await _productService.GetById(id);
            }
            catch (InvalidOperationException)
            {
                return NotFound($"Product with ID:{id} not found.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ProductViewDto>> CreateProduct(ProductCreateDto newProduct)
        {
            try
            {
                var createdProduct = await _productService.NewProduct(newProduct);
                var bytes = Convert.FromBase64String(newProduct.ImageData);
                Stream stream = new MemoryStream(bytes);
                await _productService.UploadFileToStorage(stream, newProduct.ImageFileName);
                return CreatedAtRoute("GetProductById", new { id = createdProduct.ID }, newProduct);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}