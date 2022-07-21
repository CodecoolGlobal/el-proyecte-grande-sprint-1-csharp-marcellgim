using System.Security.Claims;
using BpRobotics.Core.Model.Devices;
using BpRobotics.Core.Model.ServiceDTOs;
using BpRobotics.Services;
using Microsoft.AspNetCore.Authorization;
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


        [Authorize(Roles = "Admin,Customer")]
        [HttpGet]
        public async Task<ActionResult<List<DeviceViewDTO>>> Devices()
        {
            var identity = HttpContext.User;
            if (identity != null)
            {
                var isCustomer = int.TryParse(identity.FindFirst("functionId")?.Value, out int customerId);
                return isCustomer ? await _deviceService.GetDevices(customerId) : await _deviceService.GetDevices();
            }

            return Unauthorized();
        }

        [HttpGet("{deviceId}")]
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
                return CreatedAtRoute("ShowService", new { id = deviceId, serviceId = newService.Id}, newService);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}/services/{serviceId}")]
        public async Task<ActionResult> RemoveService(int serviceId)
        {
            try
            {
                await _deviceService.RemoveService(serviceId);
                return NoContent();
            }
            catch (InvalidOperationException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPut("{id}/services/{serviceId}")]
        public async Task<ActionResult<ServiceViewDTO>> UpdateService(ServiceUpdateDTO updateData)
        {
            try
            {
                return await _deviceService.UpdateService(updateData);
            }
            catch (InvalidOperationException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
