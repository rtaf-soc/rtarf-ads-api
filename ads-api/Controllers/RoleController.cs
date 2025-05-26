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
    public class RoleController : ControllerBase
    {
        private readonly IRoleService svc;

        [ExcludeFromCodeCoverage]
        public RoleController(IRoleService service)
        {
            svc = service;
        }

        [ExcludeFromCodeCoverage]
        // Use POST method, in the future we might send the body
        [HttpPost]
        [Route("org/{id}/action/GetRoles")]
        public IActionResult GetRoles(string id, [FromBody] VMRole param)
        {
            var result = svc.GetRoles(id, param);
            return Ok(result);
        }
    }
}
