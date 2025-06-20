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
    public class NoteController : ControllerBase
    {
        private readonly INoteService svc;

        [ExcludeFromCodeCoverage]
        public NoteController(INoteService service)
        {
            svc = service;
        }

        [ExcludeFromCodeCoverage]
        [HttpPost]
        [Route("org/{id}/action/AddNote")]
        public MVNote? AddNote(string id, [FromBody] MNote request)
        {
            var result = svc.AddNote(id, request);
            return result;
        }

        [ExcludeFromCodeCoverage]
        [HttpDelete]
        [Route("org/{id}/action/DeleteNoteById/{noteId}")]
        public IActionResult DeleteNoteById(string id, string noteId)
        {
            var result = svc.DeleteNoteById(id, noteId);
            return Ok(result);
        }

        [ExcludeFromCodeCoverage]
        [HttpGet]
        [Route("org/{id}/action/GetNoteById/{noteId}")]
        public MNote GetNoteById(string id, string noteId)
        {
            var result = svc.GetNoteById(id, noteId);
            return result;
        }

        [HttpPost]
        [Route("org/{id}/action/GetNotes")]
        public IActionResult GetNotes(string id, [FromBody] VMNote param)
        {
            if (param.Limit <= 0)
            {
                param.Limit = 100;
            }

            var result = svc.GetNotes(id, param);
            return Ok(result);
        }

        [HttpPost]
        [Route("org/{id}/action/GetNoteCount")]
        public IActionResult GetNoteCount(string id, [FromBody] VMNote param)
        {
            var result = svc.GetNoteCount(id, param);
            return Ok(result);
        }

        [ExcludeFromCodeCoverage]
        [HttpPost]
        [Route("org/{id}/action/UpdateNoteById/{noteId}")]
        public IActionResult UpdateNoteById(string id, string noteId, [FromBody] MNote request)
        {
            var result = svc.UpdateNoteById(id, noteId, request);
            return Ok(result);
        }
    }
}
