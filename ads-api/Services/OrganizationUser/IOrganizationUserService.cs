using Its.Ads.Api.Models;
using Its.Ads.Api.ModelsViews;
using Its.Ads.Api.ViewsModels;

namespace Its.Ads.Api.Services
{
    public interface IOrganizationUserService
    {
        public MVOrganizationUser? AddUser(string orgId, MOrganizationUser user);
        public MVOrganizationUser? DeleteUserById(string orgId, string userId);
        public IEnumerable<MOrganizationUser> GetUsers(string orgId, VMOrganizationUser param);
        public int GetUserCount(string orgId, VMOrganizationUser param);
        public MVOrganizationUser? UpdateUserById(string orgId, string userId, MOrganizationUser user);
        public MOrganizationUser GetUserById(string orgId, string userId);
    }
}
