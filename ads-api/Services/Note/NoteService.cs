using Its.Ads.Api.Models;
using Its.Ads.Api.ModelsViews;
using Its.Ads.Api.Database.Repositories;
using Its.Ads.Api.Utils;
using Its.Ads.Api.ViewsModels;

namespace Its.Ads.Api.Services
{
    public class NoteService : BaseService, INoteService
    {
        private readonly INoteRepository? repository = null;

        public NoteService(INoteRepository repo) : base()
        {
            repository = repo;
        }

        public MNote GetNoteById(string orgId, string noteId)
        {
            repository!.SetCustomOrgId(orgId);
            var result = repository!.GetNoteById(noteId);

            return result.Result;
        }

        public MVNote? AddNote(string orgId, MNote device)
        {
            repository!.SetCustomOrgId(orgId);

            var r = new MVNote();

            var result = repository!.AddNote(device);

            r.Status = "OK";
            r.Description = "Success";
            r.Note = result;

            return r;
        }

        public MVNote? DeleteNoteById(string orgId, string noteId)
        {
            var r = new MVNote()
            {
                Status = "OK",
                Description = "Success"
            };

            if (!ServiceUtils.IsGuidValid(noteId))
            {
                r.Status = "UUID_INVALID";
                r.Description = $"Note ID [{noteId}] format is invalid";

                return r;
            }

            repository!.SetCustomOrgId(orgId);
            var m = repository!.DeleteNoteById(noteId);

            r.Note = m;
            if (m == null)
            {
                r.Status = "NOTFOUND";
                r.Description = $"Note ID [{noteId}] not found for the organization [{orgId}]";
            }

            return r;
        }

        public IEnumerable<MNote> GetNotes(string orgId, VMNote param)
        {
            repository!.SetCustomOrgId(orgId);
            var result = repository!.GetNotes(param);

            return result;
        }

        public int GetNoteCount(string orgId, VMNote param)
        {
            repository!.SetCustomOrgId(orgId);
            var result = repository!.GetNoteCount(param);

            return result;
        }

        public MVNote? UpdateNoteById(string orgId, string noteId, MNote device)
        {
            var r = new MVNote()
            {
                Status = "OK",
                Description = "Success"
            };

            repository!.SetCustomOrgId(orgId);
            var result = repository!.UpdateNoteById(noteId, device);

            if (result == null)
            {
                r.Status = "NOTFOUND";
                r.Description = $"Note ID [{noteId}] not found for the organization [{orgId}]";

                return r;
            }

            r.Note = result;
            return r;
        }
    }
}
