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
    public class ArtifactController : ControllerBase
    {
        private readonly IArtifactService svc;

        [ExcludeFromCodeCoverage]
        public ArtifactController(IArtifactService service)
        {
            svc = service;
        }

        [ExcludeFromCodeCoverage]
        [HttpPost]
        [Route("org/{id}/action/AddArtifact")]
        public MVArtifact? AddArtifact(string id, [FromBody] MArtifact request)
        {
            var result = svc.AddArtifact(id, request);
            return result;
        }

        [ExcludeFromCodeCoverage]
        [HttpDelete]
        [Route("org/{id}/action/DeleteArtifactById/{artifactId}")]
        public IActionResult DeleteArtifactById(string id, string artifactId)
        {
            var result = svc.DeleteArtifactById(id, artifactId);
            return Ok(result);
        }

        [ExcludeFromCodeCoverage]
        [HttpDelete]
        [Route("org/{id}/action/GetArtifactById/{artifactId}")]
        public MArtifact GetArtifactById(string id, string artifactId)
        {
            var result = svc.GetArtifactById(id, artifactId);
            return result;
        }

        [HttpGet]
        [Route("org/{id}/action/GetArtifacts")]
        public IActionResult GetArtifacts(string id, [FromQuery] VMArtifact param)
        {
            if (param.Limit <= 0)
            {
                param.Limit = 100;
            }

            var result = svc.GetArtifacts(id, param);
            return Ok(result);
        }

        [HttpGet]
        [Route("org/{id}/action/GetArtifactCount")]
        public IActionResult GetArtifactCount(string id, [FromQuery] VMArtifact param)
        {
            if (param.Limit <= 0)
            {
                param.Limit = 100;
            }

            var result = svc.GetArtifactCount(id, param);
            return Ok(result);
        }
    }
}
