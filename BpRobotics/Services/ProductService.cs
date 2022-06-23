using BpRobotics.Core.Extensions;
using BpRobotics.Core.Model.ProductDTOs;
using BpRobotics.Data.Entity;
using BpRobotics.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.VisualBasic;

namespace BpRobotics.Services;

public class ProductService
{
    private readonly IRepository<Product> _productRepository;

    public ProductService(IRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<ProductViewDto>> ListProducts()
    {
        var products = await _productRepository.GetAll();
        return products.ToListProductViewDto();
    }

    public async Task<Product> NewProduct(ProductCreateDto newProduct)
    {
        var productEntity = newProduct.ToProductEntity();
        await _productRepository.Add(productEntity);
        return productEntity;
    }

    public async Task<ProductViewDto> GetById(int productId)
    {
        var product = await _productRepository.Get(productId);
        return product.ToProductViewDto();
    }

}