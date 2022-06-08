using BpRobotics.Data.Entity;

namespace BpRobotics.Data.Repositories;

public class UserRepository : IRepository<User>
{
    private readonly IBpRoboticsDataStorage _storage;

    public UserRepository(IBpRoboticsDataStorage storage)
    {
        _storage = storage;
    }

    public List<User> GetAll() => _storage.Users.ToList();

    public User Get(int id) => _storage.Users.First(user => user.Id == id);

    public void Delete(int id)
    {
        _storage.Users.Remove(Get(id));
    }

    public void Add(User entity)
    {
        entity.Id = (_storage.Users.LastOrDefault()?.Id  ?? 0) + 1;
        _storage.Users.Add(entity);
    }

    public void Update(int id, User entity)
    {
        // TODO override properties
        var userToUpdate = Get(id);
    }
}