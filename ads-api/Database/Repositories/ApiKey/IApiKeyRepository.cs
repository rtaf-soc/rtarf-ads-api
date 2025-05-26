using Its.Ads.Api.Models;
using Its.Ads.Api.ViewsModels;

namespace Its.Ads.Api.Database.Repositories
{
    public interface IApiKeyRepository
    {
        public void SetCustomOrgId(string customOrgId);
        public Task<MApiKey> GetApiKey(string apiKey);
        public MApiKey AddApiKey(MApiKey apiKey);
        public MApiKey? DeleteApiKeyById(string keyId);
        public IEnumerable<MApiKey> GetApiKeys(VMApiKey param);

        public Task<MApiKey> GetApiKeyById(string keyId);
        public int GetApiKeyCount(VMApiKey param);
        public MApiKey? UpdateApiKeyById(string keyId, MApiKey apiKey);
    }
}
