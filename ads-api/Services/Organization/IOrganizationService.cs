using Its.Ads.Api.Models;
using Its.Ads.Api.ModelsViews;

namespace Its.Ads.Api.Services
{
    public interface IOrganizationService
    {
        public Task<MOrganization> GetOrganization(string orgId);
        public MVOrganizationUser AddUserToOrganization(string orgId, MOrganizationUser user);
        public bool IsUserNameExist(string orgId, string userName);
        public MVOrganizationUser VerifyUserInOrganization(string orgId, string userName);
        public MVOrganization AddOrganization(string orgId, MOrganization org);
        public IEnumerable<MOrganizationUser> GetUserAllowedOrganization(string userName);
    }
}
