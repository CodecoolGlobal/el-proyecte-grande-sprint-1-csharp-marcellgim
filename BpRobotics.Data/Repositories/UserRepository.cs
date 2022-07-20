using BpRobotics.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace BpRobotics.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly BpRoboticsContext _context;

    public UserRepository(BpRoboticsContext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetAll() => await _context.Users.AsNoTracking().ToListAsync();

    public async Task<User> Get(int id) => await _context.Users.AsNoTracking().FirstAsync(user => user.Id == id);

    public async Task Delete(int id)
    {
        _context.Users.Remove(await Get(id));
        await _context.SaveChangesAsync();
    }

    public async Task Add(User entity)
    {
        await _context.Users.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<User> Update(User entity)
    {
        var userToUpdate = await _context.Users.SingleAsync(u => u.Id == entity.Id);
        userToUpdate.HashedPassword = entity.HashedPassword;
        userToUpdate.FirstName = entity.FirstName;
        userToUpdate.LastName = entity.LastName;
        await _context.SaveChangesAsync();
        return userToUpdate;
    }

    public async Task<User> GetByUserName(string username) => await _context.Users.AsNoTracking().FirstOrDefaultAsync(user => user.UserName == username);
}