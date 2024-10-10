using Its.Ads.Api.Models;

namespace Its.Ads.Api.Services
{
    public interface IRoleService
    {
        public IEnumerable<MRole> GetRolesList(string orgId, string rolesList);
    }
}
