using BpRobotics.Data.Model;
using BpRobotics.Data.Repositories;
using BpRobotics.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace BpRobotics.Controllers
{
    [ApiController]
    [Route("")]
    public class PartnerController : Controller
    {
        private readonly IRepository<Partner> _partnerRepository;

        public PartnerController(IRepository<Partner> partnerRepository)
        {
            _partnerRepository = partnerRepository;
        }

        [Route("partners")]
        public List<Partner> ListPartners()
        {
            return _partnerRepository.GetAll();
        }
    }
}
