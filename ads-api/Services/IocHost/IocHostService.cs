using Its.Ads.Api.Models;
using Its.Ads.Api.ModelsViews;
using Its.Ads.Api.Database.Repositories;
using Its.Ads.Api.Utils;
using Its.Ads.Api.ViewsModels;

namespace Its.Ads.Api.Services
{
    public class IocHostService : BaseService, IIocHostService
    {
        private readonly IIocHostRepository? repository = null;

        public IocHostService(IIocHostRepository repo) : base()
        {
            repository = repo;
        }

        public MIocHost GetIocHostById(string orgId, string iocHostId)
        {
            repository!.SetCustomOrgId(orgId);
            var result = repository!.GetIocHostById(iocHostId);

            return result;
        }

        public MIocHost GetIocHostByCode(string orgId, string iocHostCode)
        {
            repository!.SetCustomOrgId(orgId);
            var result = repository!.GetIocHostByCode(iocHostCode);

            return result;
        }

        public MVIocHost? AddIocHost(string orgId, MIocHost iocHost)
        {
            repository!.SetCustomOrgId(orgId);

            var r = new MVIocHost();

            var isExist = repository!.IsIocHostCodeExist(iocHost.IocHostCode!);

            if (isExist)
            {
                r.Status = "DUPLICATE";
                r.Description = $"IocHost CIDR [{iocHost.IocHostCode}] is duplicate";

                return r;
            }

            var result = repository!.AddIocHost(iocHost);

            r.Status = "OK";
            r.Description = "Success";
            r.IocHost = result;

            return r;
        }

        public MVIocHost? DeleteIocHostById(string orgId, string iocHostId)
        {
            var r = new MVIocHost()
            {
                Status = "OK",
                Description = "Success"
            };

            if (!ServiceUtils.IsGuidValid(iocHostId))
            {
                r.Status = "UUID_INVALID";
                r.Description = $"IocHost ID [{iocHostId}] format is invalid";

                return r;
            }

            repository!.SetCustomOrgId(orgId);
            var m = repository!.DeleteIocHostById(iocHostId);

            r.IocHost = m;
            if (m == null)
            {
                r.Status = "NOTFOUND";
                r.Description = $"IocHost ID [{iocHostId}] not found for the organization [{orgId}]";
            }

            return r;
        }

        public IEnumerable<MIocHost> GetIocHosts(string orgId, VMIocHost param)
        {
            repository!.SetCustomOrgId(orgId);
            var result = repository!.GetIocHosts(param);

            return result;
        }

        public int GetIocHostCount(string orgId, VMIocHost param)
        {
            repository!.SetCustomOrgId(orgId);
            var result = repository!.GetIocHostCount(param);

            return result;
        }
    }
}
