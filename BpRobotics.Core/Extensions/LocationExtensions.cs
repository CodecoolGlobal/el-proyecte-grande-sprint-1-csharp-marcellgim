using BpRobotics.Core.Model;
using BpRobotics.Core.Model.LocationDTOs;
using BpRobotics.Data.Entity;

namespace BpRobotics.Core.Extensions
{
    public static class LocationExtensions
    {
        public static LocationDTO ToLocationView(this Location location)
        {
            return new LocationDTO
            {
                ZIP = location.ZIP,
                Country = location.Country,
                City = location.City,
                Address = location.Address
            };
        }
        public static List<LocationDTO> ToLocationView(this List<Location> locations)
        {
            return locations.Select(ToLocationView).ToList();
        }

        public static Location ToLocationEntity(this LocationDTO createLocationDto)
        {
            return new Location
            {
                ZIP = createLocationDto.ZIP,
                Country = createLocationDto.Country,
                City = createLocationDto.City,
                Address = createLocationDto.Address
            };
        }

        public static Location ToUpdateLocationEntity(this LocationDTO updateLocationDto)
        {
            return new Location
            {
                Id = updateLocationDto.Id,
                ZIP = updateLocationDto.ZIP,
                Country = updateLocationDto.Country,
                City = updateLocationDto.City,
                Address = updateLocationDto.Address
            };
        }
    }
}
