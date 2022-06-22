﻿using BpRobotics.Core.Model;
using BpRobotics.Core.Model.LocationDTOs;
using BpRobotics.Data.Entity;

namespace BpRobotics.Core.Extensions
{
    public static class LocationExtensions
    {
        public static LocationDto ToLocationView(this Location location)
        {
            return new LocationDto
            {
                Zip = location.ZIP,
                Country = location.Country,
                City = location.City,
                Address = location.Address
            };
        }
        public static List<LocationDto> ToLocationView(this List<Location> locations)
        {
            return locations.Select(ToLocationView).ToList();
        }

        public static Location ToLocationEntity(this LocationDto createLocationDto)
        {
            return new Location
            {
                ZIP = createLocationDto.Zip,
                Country = createLocationDto.Country,
                City = createLocationDto.City,
                Address = createLocationDto.Address
            };
        }

        public static Location ToUpdateLocationEntity(this LocationDto updateLocationDto)
        {
            return new Location
            {
                Id = updateLocationDto.Id,
                ZIP = updateLocationDto.Zip,
                Country = updateLocationDto.Country,
                City = updateLocationDto.City,
                Address = updateLocationDto.Address
            };
        }
    }
}