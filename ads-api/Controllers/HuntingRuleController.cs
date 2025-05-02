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
    public class HuntingRuleController : ControllerBase
    {
        private readonly IHuntingRuleService svc;

        [ExcludeFromCodeCoverage]
        public HuntingRuleController(IHuntingRuleService service)
        {
            svc = service;
        }

        [ExcludeFromCodeCoverage]
        [HttpPost]
        [Route("org/{id}/action/AddHuntingRule")]
        public MVHuntingRule? AddHuntingRule(string id, [FromBody] MHuntingRule request)
        {
            var result = svc.AddHuntingRule(id, request);
            return result;
        }

        [ExcludeFromCodeCoverage]
        [HttpDelete]
        [Route("org/{id}/action/DeleteHuntingRuleById/{ruleId}")]
        public IActionResult DeleteHuntingRuleById(string id, string ruleId)
        {
            var result = svc.DeleteHuntingRuleById(id, ruleId);
            return Ok(result);
        }

        [ExcludeFromCodeCoverage]
        [HttpPost]
        [Route("org/{id}/action/UpdateHuntingRuleById/{ruleId}")]
        public IActionResult UpdateHuntingRuleById(string id, string ruleId, [FromBody] MHuntingRule request)
        {
            var result = svc.UpdateHuntingRuleById(id, ruleId, request);
            return Ok(result);
        }

        [ExcludeFromCodeCoverage]
        [HttpGet]
        [Route("org/{id}/action/GetHuntingRuleById/{ruleId}")]
        public IActionResult GetHuntingRuleById(string id, string ruleId)
        {
//Console.WriteLine("DEBUG_1");
            var result = svc.GetHuntingRuleById(id, ruleId);
//Console.WriteLine("DEBUG_2");
            return Ok(result.Result);
        }

        [HttpPost]
        [Route("org/{id}/action/GetHuntingRules")]
        public IActionResult GetHuntingRules(string id, [FromBody] VMHuntingRule param)
        {
            if (param.Limit <= 0)
            {
                param.Limit = 100;
            }

            var result = svc.GetHuntingRules(id, param);
            return Ok(result);
        }

        [HttpPost]
        [Route("org/{id}/action/GetHuntingRuleCount")]
        public IActionResult GetHuntingRuleCount(string id, [FromBody] VMHuntingRule param)
        {
            var result = svc.GetHuntingRuleCount(id, param);
            return Ok(result);
        }
    }
}
