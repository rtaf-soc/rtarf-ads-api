using Its.Ads.Api.Models;
using Its.Ads.Api.ModelsViews;
using Its.Ads.Api.ViewsModels;

namespace Its.Ads.Api.Services
{
    public interface IApiKeyService
    {
        public Task<MApiKey> GetApiKey(string orgId, string apiKey);
        public MVApiKey VerifyApiKey(string orgId, string apiKey);
        public MVApiKey? AddApiKey(string orgId, MApiKey apiKey);
        public MVApiKey? DeleteApiKeyById(string orgId, string keyId);
        public IEnumerable<MApiKey> GetApiKeys(string orgId, VMApiKey param);

        public int GetApiKeyCount(string orgId, VMApiKey param);
        public MVApiKey? UpdateApiKeyById(string orgId, string keyId, MApiKey apiKey);
        public MApiKey GetApiKeyById(string orgId, string keyId);
    }
}
