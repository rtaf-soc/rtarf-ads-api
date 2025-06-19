using Its.Ads.Api.Models;
using Its.Ads.Api.ModelsViews;
using Its.Ads.Api.ViewsModels;

namespace Its.Ads.Api.Services
{
    public interface INoteService
    {
        public MNote GetNoteById(string orgId, string noteId);
        public MVNote? AddNote(string orgId, MNote note);
        public MVNote? DeleteNoteById(string orgId, string noteId);
        public IEnumerable<MNote> GetNotes(string orgId, VMNote param);
        public int GetNoteCount(string orgId, VMNote param);
        public MVNote? UpdateNoteById(string orgId, string noteId, MNote note);
    }
}
