using Its.Ads.Api.Models;
using Its.Ads.Api.ModelsViews;
using Its.Ads.Api.ViewsModels;

namespace Its.Ads.Api.Services
{
    public interface IBlacklistService
    {
        public MBlacklist GetBlacklistById(string orgId, string artifactId);
        public MVBlacklist? AddBlacklist(string orgId, MBlacklist artifact);
        public MVBlacklist? DeleteBlacklistById(string orgId, string artifactId);
        public IEnumerable<MBlacklist> GetBlacklists(string orgId, VMBlacklist param);
        public int GetBlacklistCount(string orgId, VMBlacklist param);
        public MBlacklist GetBlacklistByCode(string orgId, string artifactCode);

        public MVBlacklist? UpdateBlacklistById(string orgId, string blacklistId, MBlacklist blacklist);
    }
}
