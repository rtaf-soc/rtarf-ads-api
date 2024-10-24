using Its.Ads.Api.Models;
using Its.Ads.Api.ModelsViews;
using Its.Ads.Api.ViewsModels;

namespace Its.Ads.Api.Services
{
    public interface IIocHostService
    {
        public MIocHost GetIocHostById(string orgId, string ipMapId);
        public MVIocHost? AddIocHost(string orgId, MIocHost ipMap);
        public MVIocHost? DeleteIocHostById(string orgId, string ipMapId);
        public IEnumerable<MIocHost> GetIocHosts(string orgId, VMIocHost param);
        public int GetIocHostCount(string orgId, VMIocHost param);
        public MIocHost GetIocHostByCode(string orgId, string iocHostCode);
    }
}
