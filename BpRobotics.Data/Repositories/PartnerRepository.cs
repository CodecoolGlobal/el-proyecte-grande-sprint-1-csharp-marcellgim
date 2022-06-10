﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BpRobotics.Data.Entity;

namespace BpRobotics.Data.Repositories
{
    public class PartnerRepository : IRepository<Partner>
    {
        private readonly IBpRoboticsDataStorage _storage;

        public PartnerRepository(IBpRoboticsDataStorage storage)
        {
            _storage = storage;
        }

        public void Add(Partner entity)
        {
            
            _storage.Partners.Add(entity);
        }

        public void Delete(int id)
        {
            _storage.Partners.Remove(Get(id));
        }

        public Partner Get(int id)
        {
            return _storage.Partners.Where(x => x.Id == id).First();
        }

        public List<Partner> GetAll()
        {
            return _storage.Partners.ToList();
        }

        public void Update(int id, Partner entity)
        {
            var partner = _storage.Partners.FirstOrDefault(x => x.Id == id);
            partner.PhoneNumber = entity.PhoneNumber;
            partner.CompanyName = entity.CompanyName;
        }
    }
}