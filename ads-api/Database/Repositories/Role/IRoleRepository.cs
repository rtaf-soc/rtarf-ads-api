using Its.Ads.Api.Models;
using Its.Ads.Api.ViewsModels;

namespace Its.Ads.Api.Database.Repositories
{
    public interface IRoleRepository
    {
        public void SetCustomOrgId(string customOrgId);
        public IEnumerable<MRole> GetRolesList(string rolesList);
        public IEnumerable<MRole> GetRoles(VMRole param);
    }
}
