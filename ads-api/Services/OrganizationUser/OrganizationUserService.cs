using Its.Ads.Api.Models;
using Its.Ads.Api.Database.Repositories;
using Its.Ads.Api.ViewsModels;
using Its.Ads.Api.ModelsViews;
using Its.Ads.Api.Utils;

namespace Its.Ads.Api.Services
{
    public class OrganizationUserService : BaseService, IOrganizationUserService
    {
        private readonly IOrganizationUserRepository? repository = null;

        public OrganizationUserService(IOrganizationUserRepository repo) : base()
        {
            repository = repo;
        }

        public IEnumerable<MOrganizationUser> GetUsers(string orgId, VMOrganizationUser param)
        {
            repository!.SetCustomOrgId(orgId);
            var result = repository!.GetUsers(param);

            return result;
        }

        public MVOrganizationUser? AddUser(string orgId, MOrganizationUser user)
        {
            repository!.SetCustomOrgId(orgId);

            var r = new MVOrganizationUser();

            var result = repository!.AddUser(user);

            r.Status = "OK";
            r.Description = "Success";
            r.OrgUser = result;

            return r;
        }

        public MVOrganizationUser? DeleteUserById(string orgId, string userId)
        {
            var r = new MVOrganizationUser()
            {
                Status = "OK",
                Description = "Success"
            };

            if (!ServiceUtils.IsGuidValid(userId))
            {
                r.Status = "UUID_INVALID";
                r.Description = $"User ID [{userId}] format is invalid";

                return r;
            }

            repository!.SetCustomOrgId(orgId);
            var m = repository!.DeleteUserById(userId);

            r.OrgUser = m;
            if (m == null)
            {
                r.Status = "NOTFOUND";
                r.Description = $"User ID [{userId}] not found for the organization [{orgId}]";
            }

            return r;
        }

        public int GetUserCount(string orgId, VMOrganizationUser param)
        {
            repository!.SetCustomOrgId(orgId);
            var result = repository!.GetUserCount(param);

            return result;
        }

        public MVOrganizationUser? UpdateUserById(string orgId, string userId, MOrganizationUser user)
        {
            var r = new MVOrganizationUser()
            {
                Status = "OK",
                Description = "Success"
            };

            repository!.SetCustomOrgId(orgId);
            var result = repository!.UpdateUserById(userId, user);

            if (result == null)
            {
                r.Status = "NOTFOUND";
                r.Description = $"User ID [{user}] not found for the organization [{orgId}]";

                return r;
            }

            r.OrgUser = result;
            return r;
        }
    }
}
