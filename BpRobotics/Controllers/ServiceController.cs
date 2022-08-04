using System.Security.Claims;
using BpRobotics.Core.Model.Devices;
using BpRobotics.Core.Model.ServiceDTOs;
using BpRobotics.Data.Entity;
using BpRobotics.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BpRobotics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly ServiceService _serviceService;

        public ServiceController(ServiceService serviceService)
        {
            _serviceService = serviceService;
        }


        //[Authorize(Roles = "Partner, Admin")]
        [HttpGet]
        public async Task<ActionResult<List<ServiceViewDTO>>> Services()
        {
            try
            {
                var identity = HttpContext.User;
                if (identity != null)
                {
                    var isPartner = int.TryParse(identity.FindFirst("functionId")?.Value, out int partnerId);
                    return isPartner ? await _serviceService.GetServices(partnerId) : await _serviceService.GetServices();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return Unauthorized();
        }


        [Authorize(Roles = "Partner, Admin")]
        [HttpPut("{serviceId}/start")]
        public async Task<ActionResult> StartService(int serviceId)
        {
            try
            {
                await _serviceService.StartService(serviceId);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "Partner, Admin")]
        [HttpPut("{serviceId}/finish")]
        public async Task<ActionResult> FinishService(int serviceId)
        {
            try
            {
                await _serviceService.FinishService(serviceId);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
