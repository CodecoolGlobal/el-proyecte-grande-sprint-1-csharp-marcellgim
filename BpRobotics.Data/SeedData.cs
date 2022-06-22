using BpRobotics.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace BpRobotics.Data;

public class SeedData
{
    private readonly BpRoboticsContext _context;

    public SeedData(BpRoboticsContext context)
    {
        _context = context;
    }

    public void Seed()
    {
        _context.Database.EnsureCreated();

        if (!_context.Users.Any())
        {
            _context.Users.AddRange(
                new()
                {
                    FirstName = "Péter",
                    LastName = "Király",
                    UserName = "MainAdmin",
                    HashedPassword = "1234",
                    Role = UserRole.Admin
                },
                new()
                {
                    FirstName = "Sutő",
                    LastName = "Károly",
                    UserName = "BossMan",
                    HashedPassword = "1234",
                    Role = UserRole.Admin
                },
                new()
                {
                    FirstName = "István",
                    LastName = "Takács",
                    UserName = "RepairMan",
                    HashedPassword = "1234",
                    Role = UserRole.Partner,
                },
                new()
                {
                    FirstName = "Anna",
                    LastName = "Partner",
                    UserName = "CreativeUsername",
                    HashedPassword = "1234",
                    Role = UserRole.Partner,
                },
                new()
                {
                    FirstName = "Lajos",
                    LastName = "Customer",
                    UserName = "EcseriFourSeasons",
                    HashedPassword = "1234",
                    Role = UserRole.Customer,
                },
                new()
                {
                    FirstName = "Huba",
                    LastName = "Hűtő",
                    UserName = "ILoveRefrigerators",
                    HashedPassword = "1234",
                    Role = UserRole.Customer,
                });
        }
    }
}