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
    public class BlacklistController : ControllerBase
    {
        private readonly IBlacklistService svc;

        [ExcludeFromCodeCoverage]
        public BlacklistController(IBlacklistService service)
        {
            svc = service;
        }

        [ExcludeFromCodeCoverage]
        [HttpPost]
        [Route("org/{id}/action/AddBlacklist")]
        public MVBlacklist? AddBlacklist(string id, [FromBody] MBlacklist request)
        {
            var result = svc.AddBlacklist(id, request);
            return result;
        }

        [ExcludeFromCodeCoverage]
        [HttpDelete]
        [Route("org/{id}/action/DeleteBlacklistById/{artifactId}")]
        public IActionResult DeleteBlacklistById(string id, string artifactId)
        {
            var result = svc.DeleteBlacklistById(id, artifactId);
            return Ok(result);
        }

        [ExcludeFromCodeCoverage]
        [HttpGet]
        [Route("org/{id}/action/GetBlacklistById/{artifactId}")]
        public MBlacklist GetBlacklistById(string id, string artifactId)
        {
            var result = svc.GetBlacklistById(id, artifactId);
            return result;
        }

        [ExcludeFromCodeCoverage]
        [HttpGet]
        [Route("org/{id}/action/GetBlackListByCode/{artifactCode}")]
        public MBlacklist GetBlackListByCode(string id, string artifactCode)
        {
            var result = svc.GetBlacklistByCode(id, artifactCode);
            return result;
        }

        [HttpPost]
        [Route("org/{id}/action/GetBlacklists")]
        public IActionResult GetBlacklists(string id, [FromBody] VMBlacklist param)
        {
            if (param.Limit <= 0)
            {
                param.Limit = 100;
            }

            var result = svc.GetBlacklists(id, param);
            return Ok(result);
        }

        [HttpPost]
        [Route("org/{id}/action/GetBlacklistCount")]
        public IActionResult GetBlacklistCount(string id, [FromBody] VMBlacklist param)
        {
            var result = svc.GetBlacklistCount(id, param);
            return Ok(result);
        }

        [ExcludeFromCodeCoverage]
        [HttpPost]
        [Route("org/{id}/action/UpdateBlacklistById/{blacklistId}")]
        public IActionResult UpdateBlacklistById(string id, string blacklistId, [FromBody] MBlacklist request)
        {
            var result = svc.UpdateBlacklistById(id, blacklistId, request);
            return Ok(result);
        }
    }
}
