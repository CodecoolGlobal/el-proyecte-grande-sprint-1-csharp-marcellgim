
using BpRobotics.Data.Entity;
using BpRobotics.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BpRobotics.Controllers
{
    [ApiController]
    [Route("partners")]
    public class PartnerController : Controller
    {
        private readonly IRepository<Partner> _partnerRepository;
        private readonly ILogger<PartnerController> _logger;

        public PartnerController(IRepository<Partner> partnerRepository, ILogger<PartnerController> logger)
        {
            _partnerRepository = partnerRepository ?? throw new ArgumentNullException(nameof(partnerRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public ActionResult<List<Partner>> ListPartners()
        {
            try
            {
            }
            catch (Exception ex)
            {
                _logger.LogCritical(
                    $"Exception while getting the list of partners.", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
            return Ok(_partnerRepository.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Partner> GetPartnerById(int id)
        {
            return Ok(_partnerRepository.Get(id));
        }

        [HttpPost]
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
