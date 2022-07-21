
using BpRobotics.Core.Model;
using BpRobotics.Data.Entity;
using BpRobotics.Data.Repositories;
using BpRobotics.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BpRobotics.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PartnersController : Controller
    {
        private readonly IPartnersService _partnerService;
        private readonly ILogger<PartnersController> _logger;

        public PartnersController(IPartnersService partnerService, ILogger<PartnersController> logger)
        {
            _partnerService = partnerService ?? throw new ArgumentNullException(nameof(partnerService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<List<PartnerViewDto>>> ListPartners()
        {
            return await _partnerService.ListPartners();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{id}", Name = "GetPartnerById")]
        public async Task<ActionResult<PartnerViewDto>> GetPartnerById(int id)
        {
            try
            {
                return await _partnerService.GetById(id);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogCritical($"No partner found with id: {id}.", ex);
                return NotFound($"Partner with ID:{id} not found.");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<PartnerViewDto>> AddNewPartner(PartnerCreateDto newPartnerDto)
        {
            try
            {
                var newPartnerViewDto = await _partnerService.NewPartner(newPartnerDto);
                return CreatedAtRoute("GetPartnerById", new { id = newPartnerViewDto.Id }, newPartnerViewDto);
            }
            catch (DbUpdateException)
            {
                return BadRequest("Something went wrong adding new partner.");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult<PartnerViewDto>> UpdatePartner(PartnerUpdateDto updatedPartnerDto, int id)
        {
            try
            {
                var updatedPartnerViewDto = await _partnerService.UpdatePartner(updatedPartnerDto);
                return updatedPartnerViewDto;
            }
            catch (DbUpdateException)
            {
                return NotFound($"Partner with ID:{updatedPartnerDto.Id} not found.");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePartner(int id)
        {
            try
            {
                await _partnerService.DeleteById(id);
                return NoContent();
            }
            catch (InvalidOperationException)
            {
                return NotFound($"Partner with ID:{id} not found.");
            }
        }
    }
}
