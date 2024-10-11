using LinqKit;
using Its.Ads.Api.Models;
using Its.Ads.Api.ViewsModels;

namespace Its.Ads.Api.Database.Repositories
{
    public class BlacklistRepository : BaseRepository, IBlacklistRepository
    {
        public BlacklistRepository(IDataContext ctx)
        {
            context = ctx;
        }

        public MBlacklist AddBlacklist(MBlacklist blacklist)
        {
            blacklist.BlacklistId = Guid.NewGuid();
            blacklist.CreatedDate = DateTime.UtcNow;
            blacklist.OrgId = orgId;

            context!.Blacklists!.Add(blacklist);
            context.SaveChanges();

            return blacklist;
        }

        private ExpressionStarter<MBlacklist> BlacklistPredicate(VMBlacklist param)
        {
            var pd = PredicateBuilder.New<MBlacklist>();

            pd = pd.And(p => p.OrgId!.Equals(orgId));

            if ((param.BlacklistType != null) && (param.BlacklistType >= 0))
            {
                pd = pd.And(p => p.BlacklistType!.Equals(param.BlacklistType));
            }

            if ((param.FullTextSearch != "") && (param.FullTextSearch != null))
            {
                var fullTextPd = PredicateBuilder.New<MBlacklist>();
                fullTextPd = fullTextPd.Or(p => p.BlacklistCode!.Contains(param.FullTextSearch));

                pd = pd.And(fullTextPd);
            }

            return pd;
        }

        public int GetBlacklistCount(VMBlacklist param)
        {
            var predicate = BlacklistPredicate(param);
            var cnt = context!.Blacklists!.Where(predicate).Count();

            return cnt;
        }

        public IEnumerable<MBlacklist> GetBlacklists(VMBlacklist param)
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

            var predicate = BlacklistPredicate(param!);
            var arr = context!.Blacklists!.Where(predicate)
                .OrderByDescending(e => e.BlacklistCode)
                .Skip(offset)
                .Take(limit)
                .ToList();

            return arr;
        }

        public MBlacklist GetBlacklistById(string artifactId)
        {
            var u = context!.Blacklists!.Where(p => p!.BlacklistId!.Equals(artifactId) && p!.OrgId!.Equals(orgId)).FirstOrDefault();
            return u!;
        }

        public MBlacklist GetBlacklistByCode(string artifactCode)
        {
            var u = context!.Blacklists!.Where(p => p!.BlacklistCode!.Equals(artifactCode) && p!.OrgId!.Equals(orgId)).FirstOrDefault();
            return u!;
        }

        public bool IsBlacklistCodeExist(string artifactCode)
        {
            var cnt = context!.Blacklists!.Where(p => p!.BlacklistCode!.Equals(artifactCode) && p!.OrgId!.Equals(orgId)).Count();
            return cnt >= 1;
        }

        public MBlacklist? DeleteBlacklistById(string artifactId)
        {
            Guid id = Guid.Parse(artifactId);

            var r = context!.Blacklists!.Where(x => x.OrgId!.Equals(orgId) && x.BlacklistId.Equals(id)).FirstOrDefault();
            if (r != null)
            {
                context!.Blacklists!.Remove(r);
                context.SaveChanges();
            }

            return r;
        }
    }
}