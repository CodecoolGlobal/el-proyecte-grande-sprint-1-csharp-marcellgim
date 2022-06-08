using BpRobotics.Data.Model;

namespace BpRobotics.Data
{
    public interface IBpRoboticsDataStorage
    {
        List<Customer> Customers { get; set; }
        List<Device> Devices { get; set; }
        List<Order> Orders { get; set; }
        List<Partner> Partners { get; set; }
        List<Service> Services { get; set; }
        List<Ticket> Tickets { get; set; }
        List<User> Users { get; set; }
        List<Product> Products { get; set; }
    }
}