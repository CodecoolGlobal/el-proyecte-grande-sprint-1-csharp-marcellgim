using BpRobotics.Core.Model.Devices;
using BpRobotics.Core.Model.ServiceDTOs;
using BpRobotics.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BpRobotics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly DeviceService _deviceService;

        public DevicesController(DeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DeviceViewDTO>> DeviceDetails(int deviceId)
        {
            try
            {
                return await _deviceService.GetById(deviceId);
            }
            catch (InvalidOperationException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("{id}/services/{serviceId}", Name = "ShowService")]
        public async Task<ActionResult<ServiceViewDTO>> ShowService(int serviceId)
        {
            try
            {
                return await _deviceService.GetService(serviceId);
            }
            catch (InvalidOperationException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost("{deviceId}/services")]
        public async Task<ActionResult<ServiceViewDTO>> AddService(int deviceId, ServiceCreateDTO service)
        {
            try
            {
                var newService = await _deviceService.AddServiceToDevice(deviceId, service);
                return CreatedAtRoute("ShowService", new { id = newService.Device.Id ,serviceId = newService.Id}, newService);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
