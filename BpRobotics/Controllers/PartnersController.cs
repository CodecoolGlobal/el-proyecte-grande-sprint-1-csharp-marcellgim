
using BpRobotics.Core.Model;
using BpRobotics.Data.Entity;
using BpRobotics.Data.Repositories;
using BpRobotics.Services;
using Microsoft.AspNetCore.Mvc;

namespace BpRobotics.Controllers
{
    [ApiController]
    [Route("partners")]
    public class PartnersController : Controller
    {
        private readonly IPartnersService _partnerService;
        private readonly ILogger<PartnersController> _logger;

        public PartnersController(IPartnersService partnerService, ILogger<PartnersController> logger)
        {
            _partnerService = partnerService ?? throw new ArgumentNullException(nameof(partnerService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public ActionResult<List<PartnerViewDto>> ListPartners()
        {
            try
            {
                return Ok(_partnerService.ListPartners());
            }
            catch (Exception ex)
            {
                _logger.LogCritical(
                    $"Exception while getting the list of partners.", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
            
        }

        [HttpGet("{id}")]
        public ActionResult<PartnerViewDto> GetPartnerById(int id)
        {
            var partner = _partnerService.GetById(id);
            if (partner != null)
            {
                return Ok(partner);
            }
            return NotFound($"Partner with ID:{id} not found.");
        }

        [HttpPost]
        //the parameter will be Partner model
        public ActionResult<PartnerViewDto> AddNewPartner(PartnerCreateDto newPartnerDto)
        {
            var newPartnerViewDto = _partnerService.NewPartner(newPartnerDto);
            return CreatedAtRoute("AddNewPartner", newPartnerViewDto);
        }

        [HttpPut("{id}")]
        public ActionResult<PartnerViewDto> UpdatePartner(PartnerUpdateDto updatedPartnerDto, int id)
        {
            var partnerFromStore = _partnerService.GetById(id);
            
            if (partnerFromStore != null)
            {
                var updatedPartnerViewDto = _partnerService.UpdatePartner(updatedPartnerDto);
                return Ok(updatedPartnerViewDto);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePartner(int id)
        {
            var partnerFromStore = _partnerService.GetById(id);

            if (partnerFromStore != null)
            {
                _partnerService.DeleteById(id);
            }
            return Ok();
        }
    }
}
