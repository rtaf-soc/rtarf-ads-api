using Its.Ads.Api.Models;
using Its.Ads.Api.Database.Repositories;
using Its.Ads.Api.ViewsModels;

namespace Its.Ads.Api.Services
{
    public class RoleService : BaseService, IRoleService
    {
        private readonly IRoleRepository? repository = null;

        public RoleService(IRoleRepository repo) : base()
        {
            repository = repo;
        }

        public IEnumerable<MRole> GetRolesList(string orgId, string rolesList)
        {
            repository!.SetCustomOrgId(orgId);
            var result = repository!.GetRolesList(rolesList);

            return result;
        }

        public IEnumerable<MRole> GetRoles(string orgId, VMRole param)
        {
            repository!.SetCustomOrgId(orgId);
            var result = repository!.GetRoles(param);

            return result;
        }
    }
}
