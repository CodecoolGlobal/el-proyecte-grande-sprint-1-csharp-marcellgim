
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
                return Ok(_partnerRepository.GetAll());
            }
            catch (Exception ex)
            {
                _logger.LogCritical(
                    $"Exception while getting the list of partners.", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
            
        }

        [HttpGet("{id}")]
        public ActionResult<Partner> GetPartnerById(int id)
        {
            var partner = _partnerRepository.Get(id);
            if (partner != null)
            {
                return Ok(_partnerRepository.Get(id));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        //the parameter will be Partner model
        public ActionResult<Partner> AddNewPartner(Partner newPartner)
        {
            int maxId = _partnerRepository.GetAll().Max(partner => partner.Id);
            newPartner.Id = maxId++;
            
            _partnerRepository.Add(newPartner);
            return CreatedAtRoute("AddNewPartner", newPartner);
        }

        [HttpPut("{id}")]
        public ActionResult UpdatePartner(Partner updatedPartner)
        {
            var partnerFromStore = _partnerRepository.Get(updatedPartner.Id);
            if (partnerFromStore == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePartner(int id)
        {
            var partnerFromStore = _partnerRepository.Get(id);
            if (partnerFromStore == null)
            {
                return NotFound();
            }
            _partnerRepository.Delete(id);
            return NoContent();
        }
    }
}
