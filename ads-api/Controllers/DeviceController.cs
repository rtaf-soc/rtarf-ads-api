using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Its.Ads.Api.Models;
using Its.Ads.Api.Services;
using Its.Ads.Api.ViewsModels;
using Its.Ads.Api.ModelsViews;

namespace Its.Ads.Api.Controllers
{
    [Authorize(Policy = "GenericRolePolicy")]
    [ApiController]
    [Route("/api/[controller]")]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceService svc;

        [ExcludeFromCodeCoverage]
        public DeviceController(IDeviceService service)
        {
            svc = service;
        }

        [ExcludeFromCodeCoverage]
        [HttpPost]
        [Route("org/{id}/action/AddDevice")]
        public MVDevice? AddDevice(string id, [FromBody] MDevice request)
        {
            var result = svc.AddDevice(id, request);
            return result;
        }

        [ExcludeFromCodeCoverage]
        [HttpDelete]
        [Route("org/{id}/action/DeleteDeviceById/{deviceId}")]
        public IActionResult DeleteDeviceById(string id, string deviceId)
        {
            var result = svc.DeleteDeviceById(id, deviceId);
            return Ok(result);
        }

        [ExcludeFromCodeCoverage]
        [HttpGet]
        [Route("org/{id}/action/GetDeviceById/{deviceId}")]
        public MDevice GetDeviceById(string id, string deviceId)
        {
            var result = svc.GetDeviceById(id, deviceId);
            return result;
        }

        [HttpPost]
        [Route("org/{id}/action/GetDevices")]
        public IActionResult GetDevices(string id, [FromBody] VMDevice param)
        {
            if (param.Limit <= 0)
            {
                param.Limit = 100;
            }

            var result = svc.GetDevices(id, param);
            return Ok(result);
        }

        [HttpPost]
        [Route("org/{id}/action/GetDeviceCount")]
        public IActionResult GetDeviceCount(string id, [FromBody] VMDevice param)
        {
            var result = svc.GetDeviceCount(id, param);
            return Ok(result);
        }

        [ExcludeFromCodeCoverage]
        [HttpPost]
        [Route("org/{id}/action/UpdateDeviceById/{deviceId}")]
        public IActionResult UpdateDeviceById(string id, string deviceId, [FromBody] MDevice request)
        {
            var result = svc.UpdateDeviceById(id, deviceId, request);
            return Ok(result);
        }
    }
}
