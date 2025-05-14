using Its.Ads.Api.Models;
using Its.Ads.Api.ViewsModels;

namespace Its.Ads.Api.Database.Repositories
{
    public interface IIpMapRepository
    {
        public void SetCustomOrgId(string customOrgId);
        public MIpMap AddIpMap(MIpMap ipMap);
        public int GetIpMapCount(VMIpMap param);
        public IEnumerable<MIpMap> GetIpMaps(VMIpMap param);
        public MIpMap GetIpMapById(string ipMapId);
        public MIpMap GetIpMapByCidr(string ipMapCidr);
        public MIpMap? DeleteIpMapById(string IpMapId);
        public bool IsIpMapCidrExist(string ipMapCidr);
        public MIpMap? UpdateIpMapById(string ipMapId, MIpMap ipMap);
    }
}
