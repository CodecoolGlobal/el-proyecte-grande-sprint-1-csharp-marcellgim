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

        [Route("partners/{id}")]
        public Partner GetPartnerById(int id)
        {
            return _partnerRepository.Get(id);
        }

        [HttpPost]
        [Route("partners/add")]
        public ActionResult AddNewPartner()
        {
            var partner = new Partner();
            partner.PhoneNumber = Request.Form["phone"];
            partner.CompanyName = Request.Form["companyname"];
            _partnerRepository.Add(partner);
            return Ok();
        }
    }
}
