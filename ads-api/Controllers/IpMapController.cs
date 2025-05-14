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
    public class IpMapController : ControllerBase
    {
        private readonly IIpMapService svc;

        [ExcludeFromCodeCoverage]
        public IpMapController(IIpMapService service)
        {
            svc = service;
        }

        [ExcludeFromCodeCoverage]
        [HttpPost]
        [Route("org/{id}/action/AddIpMap")]
        public MVIpMap? AddIpMap(string id, [FromBody] MIpMap request)
        {
            var result = svc.AddIpMap(id, request);
            return result;
        }

        [ExcludeFromCodeCoverage]
        [HttpDelete]
        [Route("org/{id}/action/DeleteIpMapById/{ipMapId}")]
        public IActionResult DeleteIpMapById(string id, string ipMapId)
        {
            var result = svc.DeleteIpMapById(id, ipMapId);
            return Ok(result);
        }

        [ExcludeFromCodeCoverage]
        [HttpGet]
        [Route("org/{id}/action/GetIpMapById/{ipMapId}")]
        public MIpMap GetIpMapById(string id, string ipMapId)
        {
            var result = svc.GetIpMapById(id, ipMapId);
            return result;
        }

        [ExcludeFromCodeCoverage]
        [HttpGet]
        [Route("org/{id}/action/GetIpMapByCidr/{cidr}")]
        public MIpMap GetIpMapByCidr(string id, string cidr)
        {
            var result = svc.GetIpMapByCidr(id, cidr);
            return result;
        }

        [HttpPost]
        [Route("org/{id}/action/GetIpMaps")]
        public IActionResult GetIpMaps(string id, [FromBody] VMIpMap param)
        {
            if (param.Limit <= 0)
            {
                param.Limit = 100;
            }

            var result = svc.GetIpMaps(id, param);
            return Ok(result);
        }

        [HttpPost]
        [Route("org/{id}/action/GetIpMapCount")]
        public IActionResult GetIpMapCount(string id, [FromBody] VMIpMap param)
        {
            var result = svc.GetIpMapCount(id, param);
            return Ok(result);
        }

        [ExcludeFromCodeCoverage]
        [HttpPost]
        [Route("org/{id}/action/UpdateIpMapById/{ipMapId}")]
        public IActionResult UpdateIpMapById(string id, string ipMapId, [FromBody] MIpMap request)
        {
            var result = svc.UpdateIpMapById(id, ipMapId, request);
            return Ok(result);
        }
    }
}
