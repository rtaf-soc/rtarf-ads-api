using Its.Ads.Api.Models;
using Its.Ads.Api.ModelsViews;
using Its.Ads.Api.ViewsModels;

namespace Its.Ads.Api.Services
{
    public interface IIpMapService
    {
        public MIpMap GetIpMapById(string orgId, string ipMapId);
        public MVIpMap? AddIpMap(string orgId, MIpMap ipMap);
        public MVIpMap? DeleteIpMapById(string orgId, string ipMapId);
        public IEnumerable<MIpMap> GetIpMaps(string orgId, VMIpMap param);
        public int GetIpMapCount(string orgId, VMIpMap param);
        public MIpMap GetIpMapByCidr(string orgId, string cidr);
    }
}
