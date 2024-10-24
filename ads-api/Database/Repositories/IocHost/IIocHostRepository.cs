using Its.Ads.Api.Models;
using Its.Ads.Api.ViewsModels;

namespace Its.Ads.Api.Database.Repositories
{
    public interface IIocHostRepository
    {
        public void SetCustomOrgId(string customOrgId);
        public MIocHost AddIocHost(MIocHost iocHost);
        public int GetIocHostCount(VMIocHost param);
        public IEnumerable<MIocHost> GetIocHosts(VMIocHost param);
        public MIocHost GetIocHostById(string iocHostId);
        public MIocHost GetIocHostByCode(string iocHostCode);
        public MIocHost? DeleteIocHostById(string IocHostId);
        public bool IsIocHostCodeExist(string iocHostCode);
    }
}
