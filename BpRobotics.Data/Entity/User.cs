﻿using System.ComponentModel.DataAnnotations;

namespace BpRobotics.Data.Entity
{
    public class User : ISoftDelete
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string HashedPassword { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public UserRole Role { get; set; }
        public bool IsDeleted { get; set; }

        public List<Partner> Partners { get; set; }
        public List<Customer> Customers { get; set; }
    }
}