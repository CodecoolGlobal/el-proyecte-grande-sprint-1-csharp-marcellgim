using BpRobotics.Core.Model;
using BpRobotics.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpRobotics.Core.Extensions
{
    public static class PartnerExtensions
    {
        public static PartnerViewDto ToPartnerViewDto(this Partner partner)
        {
            return new PartnerViewDto()
            {
                Id = partner.Id,
                CompanyName = partner.CompanyName,
                PhoneNumber = partner.PhoneNumber,
                ConnectedUser = partner.User ==  null ? "" : $"{partner.User.FirstName} {partner.User.LastName}"
            };
        }
        public static List<PartnerViewDto> ToPartnerViewDto(this List<Partner> partners)
        {
            List<PartnerViewDto> result = new List<PartnerViewDto>();
            foreach (var partner in partners)
            {
                result.Add(ToPartnerViewDto(partner));
            }
            return result;
        }

        public static PartnerCreateDto ToPartnerCreateDto(this Partner partner)
        {
            return new PartnerCreateDto()
            {
                CompanyName = partner.CompanyName,
                PhoneNumber = partner.PhoneNumber,
            };
        }

        public static PartnerUpdateDto ToPartnerUpdateDto(this Partner partner)
        {
            return new PartnerUpdateDto()
            {
                Id = partner.Id,
                CompanyName = partner.CompanyName,
                PhoneNumber = partner.PhoneNumber,
            };
        }

        public static Partner ToPartnerEntity(this PartnerCreateDto partner)
        {
            return new Partner()
            {
                CompanyName = partner.CompanyName,
                PhoneNumber = partner.PhoneNumber,
                UserId = partner.UserId,
            };
        }

        public static Partner ToPartnerEntity(this PartnerUpdateDto partner)
        {
            return new Partner()
            {
                Id = partner.Id,
                CompanyName = partner.CompanyName,
                PhoneNumber = partner.PhoneNumber,
            };
        }
    }
}
