using Its.Ads.Api.Models;
using Its.Ads.Api.ModelsViews;
using Its.Ads.Api.Database.Repositories;
using Its.Ads.Api.Utils;
using Its.Ads.Api.ViewsModels;

namespace Its.Ads.Api.Services
{
    public class BlacklistService : BaseService, IBlacklistService
    {
        private readonly IBlacklistRepository? repository = null;

        public BlacklistService(IBlacklistRepository repo) : base()
        {
            repository = repo;
        }

        public MBlacklist GetBlacklistById(string orgId, string artifactId)
        {
            repository!.SetCustomOrgId(orgId);
            var result = repository!.GetBlacklistById(artifactId);

            return result;
        }

        public MBlacklist GetBlacklistByCode(string orgId, string artifactCode)
        {
            repository!.SetCustomOrgId(orgId);
            var result = repository!.GetBlacklistByCode(artifactCode);

            return result;
        }

        public MVBlacklist? AddBlacklist(string orgId, MBlacklist artifact)
        {
            repository!.SetCustomOrgId(orgId);

            var r = new MVBlacklist();

            var isExist = repository!.IsBlacklistCodeExist(artifact.BlacklistCode!, artifact.BlacklistType!);

            if (isExist)
            {
                r.Status = "DUPLICATE";
                r.Description = $"Blacklist code [{artifact.BlacklistCode}] is duplicate";

                return r;
            }

            var result = repository!.AddBlacklist(artifact);

            r.Status = "OK";
            r.Description = "Success";
            r.Blacklist = result;

            return r;
        }

        public MVBlacklist? DeleteBlacklistById(string orgId, string artifactId)
        {
            var r = new MVBlacklist()
            {
                Status = "OK",
                Description = "Success"
            };

            if (!ServiceUtils.IsGuidValid(artifactId))
            {
                r.Status = "UUID_INVALID";
                r.Description = $"Blacklist ID [{artifactId}] format is invalid";

                return r;
            }

            repository!.SetCustomOrgId(orgId);
            var m = repository!.DeleteBlacklistById(artifactId);

            r.Blacklist = m;
            if (m == null)
            {
                r.Status = "NOTFOUND";
                r.Description = $"Blacklist ID [{artifactId}] not found for the organization [{orgId}]";
            }

            return r;
        }

        public IEnumerable<MBlacklist> GetBlacklists(string orgId, VMBlacklist param)
        {
            repository!.SetCustomOrgId(orgId);
            var result = repository!.GetBlacklists(param);

            return result;
        }

        public int GetBlacklistCount(string orgId, VMBlacklist param)
        {
            repository!.SetCustomOrgId(orgId);
            var result = repository!.GetBlacklistCount(param);

            return result;
        }

        public MVBlacklist? UpdateBlacklistById(string orgId, string blacklistId, MBlacklist blacklist)
        {
            var r = new MVBlacklist()
            {
                Status = "OK",
                Description = "Success"
            };

            repository!.SetCustomOrgId(orgId);
            var result = repository!.UpdateBlackListById(blacklistId, blacklist);

            if (result == null)
            {
                r.Status = "NOTFOUND";
                r.Description = $"Blacklist ID [{blacklistId}] not found for the organization [{orgId}]";

                return r;
            }

            r.Blacklist = result;
            return r;
        }
    }
}
