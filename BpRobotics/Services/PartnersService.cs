﻿using BpRobotics.Core.Model;
using BpRobotics.Data.Entity;
using BpRobotics.Data.Repositories;
using BpRobotics.Core.Extensions;

namespace BpRobotics.Services
{
    public class PartnersService : IPartnersService
    {
        private readonly IRepository<Partner> _partnerRepository;

        public PartnersService(IRepository<Partner> partnerRepository)
        {
            _partnerRepository = partnerRepository;
        }

        public async Task<List<PartnerViewDto>> ListPartners()
        {
            var entities = await _partnerRepository.GetAll();
            return entities.ToPartnerViewDto();
        }
        public async Task<PartnerViewDto> NewPartner(PartnerCreateDto newPartnerDto)
        {
            var entity = newPartnerDto.ToPartnerEntity();
            await _partnerRepository.Add(entity);
            return entity.ToPartnerViewDto();
        }

        public async Task<PartnerViewDto> GetById(int userId)
        {
            var entity = await _partnerRepository.Get(userId);
            return entity.ToPartnerViewDto();
        }
        public async Task DeleteById(int userId) => await _partnerRepository.Delete(userId);

        public async Task<PartnerViewDto> UpdatePartner(PartnerUpdateDto updatedUserDto)
        {
            var entity = await _partnerRepository.Update(updatedUserDto.ToPartnerEntity());
            return entity.ToPartnerViewDto();
        }
    }
}
