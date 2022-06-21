using BpRobotics.Core.Model;
using BpRobotics.Data.Entity;

namespace BpRobotics.Services
{
    public interface IPartnersService
    {
        public Task<List<PartnerViewDto>> ListPartners();

        public Task<PartnerViewDto> NewPartner(PartnerCreateDto newPartnerDto);

        public Task<PartnerViewDto> GetById(int userId);

        public Task DeleteById(int userId);

        public Task<PartnerViewDto> UpdateUser(PartnerUpdateDto updatedUserDto);
    }
}
