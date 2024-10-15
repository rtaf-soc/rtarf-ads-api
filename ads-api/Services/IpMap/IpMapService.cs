using Its.Ads.Api.Models;
using Its.Ads.Api.ModelsViews;
using Its.Ads.Api.Database.Repositories;
using Its.Ads.Api.Utils;
using Its.Ads.Api.ViewsModels;

namespace Its.Ads.Api.Services
{
    public class IpMapService : BaseService, IIpMapService
    {
        private readonly IIpMapRepository? repository = null;

        public IpMapService(IIpMapRepository repo) : base()
        {
            repository = repo;
        }

        public MIpMap GetIpMapById(string orgId, string ipMapId)
        {
            repository!.SetCustomOrgId(orgId);
            var result = repository!.GetIpMapById(ipMapId);

            return result;
        }

        public MIpMap GetIpMapByCidr(string orgId, string cidr)
        {
            repository!.SetCustomOrgId(orgId);
            var result = repository!.GetIpMapByCidr(cidr);

            return result;
        }

        public MVIpMap? AddIpMap(string orgId, MIpMap ipMap)
        {
            repository!.SetCustomOrgId(orgId);

            var r = new MVIpMap();

            var isExist = repository!.IsIpMapCidrExist(ipMap.Cidr!);

            if (isExist)
            {
                r.Status = "DUPLICATE";
                r.Description = $"IpMap CIDR [{ipMap.Cidr}] is duplicate";

                return r;
            }

            var result = repository!.AddIpMap(ipMap);

            r.Status = "OK";
            r.Description = "Success";
            r.IpMap = result;

            return r;
        }

        public MVIpMap? DeleteIpMapById(string orgId, string ipMapId)
        {
            var r = new MVIpMap()
            {
                Status = "OK",
                Description = "Success"
            };

            if (!ServiceUtils.IsGuidValid(ipMapId))
            {
                r.Status = "UUID_INVALID";
                r.Description = $"IpMap ID [{ipMapId}] format is invalid";

                return r;
            }

            repository!.SetCustomOrgId(orgId);
            var m = repository!.DeleteIpMapById(ipMapId);

            r.IpMap = m;
            if (m == null)
            {
                r.Status = "NOTFOUND";
                r.Description = $"IpMap ID [{ipMapId}] not found for the organization [{orgId}]";
            }

            return r;
        }

        public IEnumerable<MIpMap> GetIpMaps(string orgId, VMIpMap param)
        {
            repository!.SetCustomOrgId(orgId);
            var result = repository!.GetIpMaps(param);

            return result;
        }

        public int GetIpMapCount(string orgId, VMIpMap param)
        {
            repository!.SetCustomOrgId(orgId);
            var result = repository!.GetIpMapCount(param);

            return result;
        }
    }
}
