using LinqKit;
using Its.Ads.Api.Models;
using Its.Ads.Api.ViewsModels;

namespace Its.Ads.Api.Database.Repositories
{
    public class IocHostRepository : BaseRepository, IIocHostRepository
    {
        public IocHostRepository(IDataContext ctx)
        {
            context = ctx;
        }

        public MIocHost AddIocHost(MIocHost iocHost)
        {
            iocHost.IocHostId = Guid.NewGuid();
            iocHost.CreatedDate = DateTime.UtcNow;
            iocHost.OrgId = orgId;

            context!.IocHosts!.Add(iocHost);
            context.SaveChanges();

            return iocHost;
        }

        private ExpressionStarter<MIocHost> IocHostPredicate(VMIocHost param)
        {
            var pd = PredicateBuilder.New<MIocHost>();

            pd = pd.And(p => p.OrgId!.Equals(orgId));

            if ((param.IocType != null) && (param.IocType != ""))
            {
                pd = pd.And(p => p.IocType!.Equals(param.IocType));
            }

            if ((param.FullTextSearch != "") && (param.FullTextSearch != null))
            {
                var fullTextPd = PredicateBuilder.New<MIocHost>();
                fullTextPd = fullTextPd.Or(p => p.IocHostCode!.Contains(param.FullTextSearch));
                fullTextPd = fullTextPd.Or(p => p.Description!.Contains(param.FullTextSearch));
                fullTextPd = fullTextPd.Or(p => p.Tags!.Contains(param.FullTextSearch));

                pd = pd.And(fullTextPd);
            }

            return pd;
        }

        public int GetIocHostCount(VMIocHost param)
        {
            var predicate = IocHostPredicate(param);
            var cnt = context!.IocHosts!.Where(predicate).Count();

            return cnt;
        }

        public IEnumerable<MIocHost> GetIocHosts(VMIocHost param)
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

            var predicate = IocHostPredicate(param!);
            var arr = context!.IocHosts!.Where(predicate)
                .OrderByDescending(e => e.IocHostCode)
                .Skip(offset)
                .Take(limit)
                .ToList();

            return arr;
        }

        public MIocHost GetIocHostById(string ipMapId)
        {
            Guid id = Guid.Parse(ipMapId);

            var u = context!.IocHosts!.Where(p => p!.IocHostId!.Equals(id) && p!.OrgId!.Equals(orgId)).FirstOrDefault();
            return u!;
        }

        public MIocHost GetIocHostByCode(string iocHostCode)
        {
            var u = context!.IocHosts!.Where(p => p!.IocHostCode!.Equals(iocHostCode) && p!.OrgId!.Equals(orgId)).FirstOrDefault();
            return u!;
        }

        public bool IsIocHostCodeExist(string iocHostCode)
        {
            var cnt = context!.IocHosts!.Where(p => p!.IocHostCode!.Equals(iocHostCode)
                && p!.OrgId!.Equals(orgId)).Count();
            return cnt >= 1;
        }

        public MIocHost? DeleteIocHostById(string IocHostId)
        {
            Guid id = Guid.Parse(IocHostId);

            var r = context!.IocHosts!.Where(x => x.OrgId!.Equals(orgId) && x.IocHostId.Equals(id)).FirstOrDefault();
            if (r != null)
            {
                context!.IocHosts!.Remove(r);
                context.SaveChanges();
            }

            return r;
        }

        public MIocHost? UpdateIocHostById(string IocHostId, MIocHost iocHost)
        {
            Guid id = Guid.Parse(IocHostId);
            var result = context!.IocHosts!.Where(x => x.OrgId!.Equals(orgId) && x.IocHostId!.Equals(id)).FirstOrDefault();

            if (result != null)
            {
                result.IocEndpoint = iocHost.IocEndpoint;
                result.AuthenticationKey = iocHost.AuthenticationKey;
                result.Description = iocHost.Description;
                result.Tags = iocHost.Tags;

                context!.SaveChanges();
            }

            return result!;
        }
    }
}