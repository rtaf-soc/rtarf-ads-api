using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Its.Ads.Api.Services;
using Its.Ads.Api.ViewsModels;

namespace Its.Ads.Api.Controllers
{
    [Authorize(Policy = "GenericRolePolicy")]
    [ApiController]
    [Route("/api/[controller]")]
    public class AnalyticController : ControllerBase
    {
        private readonly IAnalyticService svc;

        [ExcludeFromCodeCoverage]
        public AnalyticController(IAnalyticService service)
        {
            svc = service;
        }

        [ExcludeFromCodeCoverage]
        [HttpGet]
        [Route("org/{id}/action/GetDefConStatus")]
        public IActionResult GetDefConStatus(string id)
        {
            var result = svc.GetDefConStatus(id);            
            return Ok(result);
        }

        [ExcludeFromCodeCoverage]
        [HttpGet]
        [Route("org/{id}/action/GetReconCountries")]
        public IActionResult GetReconCountries(string id)
        {
            var result = svc.GetReconCountries(id);            
            return Ok(result);
        }

        [ExcludeFromCodeCoverage]
        [HttpGet]
        [Route("org/{id}/action/GetThreatDistributions")]
        public IActionResult GetThreatDistributions(string id)
        {
            var result = svc.GetThreatCategories(id);            
            return Ok(result);
        }

        [ExcludeFromCodeCoverage]
        [HttpGet]
        [Route("org/{id}/action/GetThreatAlerts")]
        public IActionResult GetThreatAlerts(string id)
        {
            var result = svc.GetThreatAlerts(id);            
            return Ok(result);
        }

        [ExcludeFromCodeCoverage]
        [HttpGet]
        [Route("org/{id}/action/GetThreatSeverities")]
        public IActionResult GetThreatSeverities(string id)
        {
            var result = svc.GetThreatSeverities(id);            
            return Ok(result);
        }

        [ExcludeFromCodeCoverage]
        [HttpPost]
        [Route("org/{id}/action/GetMitreStats")]
        public IActionResult GetMitreStats(string id, [FromBody] VMMitrStat request)
        {
            var result = svc.GetMitrStats(id, request.FromDate, request.ToDate);            
            return Ok(result);
        }
    }
}
