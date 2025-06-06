using Its.Ads.Api.Models;
using Its.Ads.Api.ModelsViews;
using Its.Ads.Api.ViewsModels;

namespace Its.Ads.Api.Database.Repositories
{
    public interface IOrganizationUserRepository
    {
        public void SetCustomOrgId(string customOrgId);
        public Task<MOrganizationUser> GetUserById(string orgUserId);
        public MOrganizationUser AddUser(MOrganizationUser user);
        public MOrganizationUser? DeleteUserById(string orgUserId);
        public IEnumerable<MOrganizationUser> GetUsers(VMOrganizationUser param);
        public int GetUserCount(VMOrganizationUser param);
        public MOrganizationUser? UpdateUserById(string orgUserId, MOrganizationUser user);
    }
}
