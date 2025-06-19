using Its.Ads.Api.Models;
using Its.Ads.Api.ViewsModels;

namespace Its.Ads.Api.Database.Repositories
{
    public interface INoteRepository
    {
        public void SetCustomOrgId(string customOrgId);
        public Task<MNote> GetNoteById(string noteId);
        public MNote AddNote(MNote note);
        public MNote? DeleteNoteById(string noteId);
        public IEnumerable<MNote> GetNotes(VMNote param);
        public int GetNoteCount(VMNote param);
        public MNote? UpdateNoteById(string noteId, MNote note);
    }
}
