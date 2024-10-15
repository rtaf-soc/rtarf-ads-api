using LinqKit;
using Its.Ads.Api.Models;
using Its.Ads.Api.ViewsModels;

namespace Its.Ads.Api.Database.Repositories
{
    public class IpMapRepository : BaseRepository, IIpMapRepository
    {
        public IpMapRepository(IDataContext ctx)
        {
            context = ctx;
        }

        public MIpMap AddIpMap(MIpMap blacklist)
        {
            blacklist.IpMapId = Guid.NewGuid();
            blacklist.CreatedDate = DateTime.UtcNow;
            blacklist.OrgId = orgId;

            context!.IpMaps!.Add(blacklist);
            context.SaveChanges();

            return blacklist;
        }

        private ExpressionStarter<MIpMap> IpMapPredicate(VMIpMap param)
        {
            var pd = PredicateBuilder.New<MIpMap>();

            pd = pd.And(p => p.OrgId!.Equals(orgId));

            if ((param.FullTextSearch != "") && (param.FullTextSearch != null))
            {
                var fullTextPd = PredicateBuilder.New<MIpMap>();
                fullTextPd = fullTextPd.Or(p => p.Cidr!.Contains(param.FullTextSearch));
                fullTextPd = fullTextPd.Or(p => p.Zone!.Contains(param.FullTextSearch));

                pd = pd.And(fullTextPd);
            }

            return pd;
        }

        public int GetIpMapCount(VMIpMap param)
        {
            var predicate = IpMapPredicate(param);
            var cnt = context!.IpMaps!.Where(predicate).Count();

            return cnt;
        }

        public IEnumerable<MIpMap> GetIpMaps(VMIpMap param)
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

            var predicate = IpMapPredicate(param!);
            var arr = context!.IpMaps!.Where(predicate)
                .OrderByDescending(e => e.Cidr)
                .Skip(offset)
                .Take(limit)
                .ToList();

            return arr;
        }

        public MIpMap GetIpMapById(string ipMapId)
        {
            Guid id = Guid.Parse(ipMapId);

            var u = context!.IpMaps!.Where(p => p!.IpMapId!.Equals(id) && p!.OrgId!.Equals(orgId)).FirstOrDefault();
            return u!;
        }

        public MIpMap GetIpMapByCidr(string ipMapCidr)
        {
            var u = context!.IpMaps!.Where(p => p!.Cidr!.Equals(ipMapCidr) && p!.OrgId!.Equals(orgId)).FirstOrDefault();
            return u!;
        }

        public bool IsIpMapCidrExist(string ipMapCidr)
        {
            var cnt = context!.IpMaps!.Where(p => p!.Cidr!.Equals(ipMapCidr)
                && p!.OrgId!.Equals(orgId)).Count();
            return cnt >= 1;
        }

        public MIpMap? DeleteIpMapById(string ipMapId)
        {
            Guid id = Guid.Parse(ipMapId);

            var r = context!.IpMaps!.Where(x => x.OrgId!.Equals(orgId) && x.IpMapId.Equals(id)).FirstOrDefault();
            if (r != null)
            {
                context!.IpMaps!.Remove(r);
                context.SaveChanges();
            }

            return r;
        }
    }
}