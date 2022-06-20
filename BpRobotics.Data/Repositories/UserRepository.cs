using BpRobotics.Data.Entity;

namespace BpRobotics.Data.Repositories;

public class UserRepository : IRepository<User>
{
    private readonly IBpRoboticsDataStorage _storage;

    public UserRepository(IBpRoboticsDataStorage storage)
    {
        _storage = storage;
    }

    public async Task<List<User>> GetAll() => _storage.Users.ToList();

    public async Task<User> Get(int id) => _storage.Users.First(user => user.Id == id);

    public async Task Delete(int id)
    {
        _storage.Users.Remove(await Get(id));
    }

    public async Task Add(User entity)
    {
        entity.Id = (_storage.Users.LastOrDefault()?.Id ?? 0) + 1;
        _storage.Users.Add(entity);
    }

    public async Task<User> Update(User entity)
    {
        // TODO override properties
        var userToUpdate = await Get(entity.Id);
        _storage.Users.Remove(userToUpdate);
        _storage.Users.Add(entity);
        return entity;
    }
}