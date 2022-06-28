using BpRobotics.Data.Entity;
using Microsoft.EntityFrameworkCore;
namespace BpRobotics.Data.Repositories;

public class ProductRepository : IRepository<Product>
{
    private readonly BpRoboticsContext _context;

    public ProductRepository(BpRoboticsContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetAll()
    {
         return await _context.Products
             .AsNoTracking()
             .ToListAsync();
    }

    public async Task<Product> Get(int id)
    {
        return await _context.Products
            .AsNoTracking()
            .SingleAsync(user => user.ID == id);
    } 

    public async Task Delete(int id)
    {
        _context.Products.Remove(await Get(id));
        await _context.SaveChangesAsync();
    }

    public async Task Add(Product newProduct)
    {
        _context.Products.Add(newProduct);
        await _context.SaveChangesAsync();
    }

    public async Task<Product> Update(Product updatedProduct)
    {
        Product product = await _context.Products.SingleAsync(product => product.ID == updatedProduct.ID);
        product.Warranty = updatedProduct.Warranty;
        product.Name = updatedProduct.Name;
        product.ServiceInterval = updatedProduct.ServiceInterval;
        product.ShortDescription = updatedProduct.ShortDescription;
        product.ImageFileName = updatedProduct.ImageFileName;
        product.LongDescription = updatedProduct.LongDescription;
        await _context.SaveChangesAsync();
        return product;
    }
}