using Its.Ads.Api.Models;
using Its.Ads.Api.ViewsModels;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace Its.Ads.Api.Database.Repositories
{
    public class NoteRepository : BaseRepository, INoteRepository
    {
        public NoteRepository(IDataContext ctx)
        {
            context = ctx;
        }

        public Task<MNote> GetNoteById(string noteId)
        {
            Guid id = Guid.Parse(noteId);
            var result = context!.Notes!.Where(x => x.OrgId!.Equals(orgId) && x.Id!.Equals(id)).FirstOrDefaultAsync();

            return result!;
        }

        public MNote AddNote(MNote note)
        {
            note.Id = Guid.NewGuid();
            note.CreatedDate = DateTime.UtcNow;
            note.OrgId = orgId;

            context!.Notes!.Add(note);
            context.SaveChanges();

            return note;
        }

        public MNote? DeleteNoteById(string noteId)
        {
            Guid id = Guid.Parse(noteId);

            var r = context!.Notes!.Where(x => x.OrgId!.Equals(orgId) && x.Id.Equals(id)).FirstOrDefault();
            if (r != null)
            {
                context!.Notes!.Remove(r);
                context.SaveChanges();
            }

            return r;
        }

        public IEnumerable<MNote> GetNotes(VMNote param)
        {
            var limit = 0;
            var offset = 0;

            //Param will never be null
            if (param.Offset > 0)
            {
                //Convert to zero base
                offset = param.Offset-1;
            }

            if (param.Limit > 0)
            {
                limit = param.Limit;
            }

            var predicate = NotePredicate(param!);
            var arr = context!.Notes!.Where(predicate)
                .OrderByDescending(e => e.CreatedDate)
                .Skip(offset)
                .Take(limit)
                .ToList();

            return arr;
        }

        private ExpressionStarter<MNote> NotePredicate(VMNote param)
        {
            var pd = PredicateBuilder.New<MNote>();

            pd = pd.And(p => p.OrgId!.Equals(orgId));

            if ((param.FullTextSearch != "") && (param.FullTextSearch != null))
            {
                var fullTextPd = PredicateBuilder.New<MNote>();
                fullTextPd = fullTextPd.Or(p => p.Header!.Contains(param.FullTextSearch));
                fullTextPd = fullTextPd.Or(p => p.Description!.Contains(param.FullTextSearch));
                fullTextPd = fullTextPd.Or(p => p.Owner!.Contains(param.FullTextSearch));
                fullTextPd = fullTextPd.Or(p => p.Tags!.Contains(param.FullTextSearch));

                pd = pd.And(fullTextPd);
            }

            return pd;
        }

        public int GetNoteCount(VMNote param)
        {
            var predicate = NotePredicate(param);
            var cnt = context!.Notes!.Where(predicate).Count();

            return cnt;
        }

        public MNote? UpdateNoteById(string noteId, MNote note)
        {
            Guid id = Guid.Parse(noteId);
            var result = context!.Notes!.Where(x => x.OrgId!.Equals(orgId) && x.Id!.Equals(id)).FirstOrDefault();

            if (result != null)
            {
                result.Description = note.Description;
                result.Header = note.Header;
                result.Tags = note.Tags;
                result.Owner = note.Owner;

                context!.SaveChanges();
            }

            return result!;
        }
    }
}