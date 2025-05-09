using Its.Ads.Api.Models;
using Its.Ads.Api.ViewsModels;

namespace Its.Ads.Api.Database.Repositories
{
    public interface IBlacklistRepository
    {
        public void SetCustomOrgId(string customOrgId);
        public MBlacklist AddBlacklist(MBlacklist blacklist);
        public int GetBlacklistCount(VMBlacklist param);
        public IEnumerable<MBlacklist> GetBlacklists(VMBlacklist param);
        public MBlacklist GetBlacklistById(string blacklistId);
        public MBlacklist GetBlacklistByCode(string blacklistCode);
        public MBlacklist? DeleteBlacklistById(string blacklistId);
        public bool IsBlacklistCodeExist(string blacklistCode, int? blacklistType);
        public MBlacklist? UpdateBlackListById(string blacklistId, MBlacklist blacklist);
    }
}
