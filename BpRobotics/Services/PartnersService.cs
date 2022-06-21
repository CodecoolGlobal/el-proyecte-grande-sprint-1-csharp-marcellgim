using BpRobotics.Core.Model;
using BpRobotics.Data.Entity;
using BpRobotics.Data.Repositories;
using BpRobotics.Core.Extensions;

namespace BpRobotics.Services
{
    public class PartnersService
    {
        private readonly IRepository<Partner> _partnerRepository;

        public PartnersService(IRepository<Partner> partnerRepository)
        {
            _partnerRepository = partnerRepository;
        }

        public async Task<List<Partner>> ListPartners() => await _partnerRepository.GetAll();

        public async Task<Partner> NewPartner(PartnerCreateDto newPartnerDto)
        {
            return await _partnerRepository.Add(newPartnerDto.ToPartnerEntity());
        }

        public async Task<Partner> GetById(int userId) => await _partnerRepository.Get(userId);

        public async Task DeleteById(int userId) => await _partnerRepository.Delete(userId);

        public async Task<Partner> UpdateUser(PartnerUpdateDto updatedUserDto)
        {
            return await _partnerRepository.Update(updatedUserDto.ToPartnerEntity());
        }
    }
}
