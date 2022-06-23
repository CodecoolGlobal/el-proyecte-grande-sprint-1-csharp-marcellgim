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
        public async Task<ActionResult> GetAll()
        {
            var products = await _productService.ListProducts();
            return Ok(products);
        }

        [HttpGet("{id}", Name = "GetProductById")]
        public async Task<ActionResult> GetProductById(int id)
        {
            try
            {
                var product = await _productService.GetById(id);
                return Ok(product);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct([FromBody] ProductCreateDto newProduct)
        {
            try
            {
                var createdProduct = await _productService.NewProduct(newProduct);
                var bytes = Convert.FromBase64String(newProduct.ImageData);
                Stream stream = new MemoryStream(bytes);
                await _productService.UploadFileToStorage(stream, newProduct.ImageFileName);
                return CreatedAtRoute("GetProductById", new { id = createdProduct.ID }, newProduct);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}