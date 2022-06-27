
using BpRobotics.Core.Model;
using BpRobotics.Data.Entity;
using BpRobotics.Data.Repositories;
using BpRobotics.Services;
using Microsoft.AspNetCore.Mvc;

namespace BpRobotics.Controllers
{
    [ApiController]
    [Route("api/partners")]
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
        public async Task<ActionResult<List<PartnerViewDto>>> ListPartners()
        {
            try
            {
                return await _partnerService.ListPartners();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(
                    $"Exception while getting the list of partners.", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
            
        }

        [HttpGet("{id}", Name = "GetPartnerById")]
        public async Task<ActionResult<PartnerViewDto>> GetPartnerById(int id)
        {
            var partner = await _partnerService.GetById(id);
            if (partner != null)
            {
                return Ok(partner);
            }
            return NotFound($"Partner with ID:{id} not found.");
        }

        [HttpPost]
        //the parameter will be Partner model
        public async Task<ActionResult<PartnerViewDto>> AddNewPartner(PartnerCreateDto newPartnerDto)
        {
            var newPartnerViewDto = await _partnerService.NewPartner(newPartnerDto);
            return CreatedAtRoute("GetPartnerById", new { id = newPartnerViewDto.Id }, newPartnerViewDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PartnerViewDto>> UpdatePartner(PartnerUpdateDto updatedPartnerDto, int id)
        {
            var partnerFromStore = await _partnerService.GetById(id);
            
            if (partnerFromStore != null)
            {
                var updatedPartnerViewDto = await _partnerService.UpdatePartner(updatedPartnerDto);
                return Ok(updatedPartnerViewDto);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePartner(int id)
        {
            var partnerFromStore = await _partnerService.GetById(id);

            if (partnerFromStore != null)
            {
                await _partnerService.DeleteById(id);
            }
            return Ok();
        }
    }
}
