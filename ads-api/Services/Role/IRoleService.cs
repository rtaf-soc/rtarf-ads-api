using Its.Ads.Api.Models;
using Its.Ads.Api.ViewsModels;

namespace Its.Ads.Api.Services
{
    public interface IRoleService
    {
        public IEnumerable<MRole> GetRolesList(string orgId, string rolesList);
        public IEnumerable<MRole> GetRoles(string orgId, VMRole param);
    }
}
