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
    public class IocHostController : ControllerBase
    {
        private readonly IIocHostService svc;

        [ExcludeFromCodeCoverage]
        public IocHostController(IIocHostService service)
        {
            svc = service;
        }

        [ExcludeFromCodeCoverage]
        [HttpPost]
        [Route("org/{id}/action/AddIocHost")]
        public MVIocHost? AddIocHost(string id, [FromBody] MIocHost request)
        {
            var result = svc.AddIocHost(id, request);
            return result;
        }

        [ExcludeFromCodeCoverage]
        [HttpDelete]
        [Route("org/{id}/action/DeleteIocHostById/{iocHostId}")]
        public IActionResult DeleteIocHostById(string id, string iocHostId)
        {
            var result = svc.DeleteIocHostById(id, iocHostId);
            return Ok(result);
        }

        [ExcludeFromCodeCoverage]
        [HttpGet]
        [Route("org/{id}/action/GetIocHostById/{iocHostId}")]
        public MIocHost GetIocHostById(string id, string iocHostId)
        {
            var result = svc.GetIocHostById(id, iocHostId);
            return result;
        }

        [ExcludeFromCodeCoverage]
        [HttpGet]
        [Route("org/{id}/action/GetIocHostByCode/{code}")]
        public MIocHost GetIocHostByCode(string id, string code)
        {
            var result = svc.GetIocHostByCode(id, code);
            return result;
        }

        [HttpPost]
        [Route("org/{id}/action/GetIocHosts")]
        public IActionResult GetIocHosts(string id, [FromBody] VMIocHost param)
        {
            if (param.Limit <= 0)
            {
                param.Limit = 100;
            }

            var result = svc.GetIocHosts(id, param);
            return Ok(result);
        }

        [HttpPost]
        [Route("org/{id}/action/GetIocHostCount")]
        public IActionResult GetIocHostCount(string id, [FromBody] VMIocHost param)
        {
            var result = svc.GetIocHostCount(id, param);
            return Ok(result);
        }
    }
}
