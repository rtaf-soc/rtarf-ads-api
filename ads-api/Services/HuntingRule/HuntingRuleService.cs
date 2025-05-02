using Its.Ads.Api.Models;
using Its.Ads.Api.ModelsViews;
using Its.Ads.Api.Database.Repositories;
using Its.Ads.Api.ViewsModels;
using Its.Ads.Api.Utils;

namespace Its.Ads.Api.Services
{
    public class HuntingRuleService : BaseService, IHuntingRuleService
    {
        private readonly IHuntingRuleRepository? repository = null;
        private DateTime compareDate = DateTime.Now;

        public HuntingRuleService(IHuntingRuleRepository repo) : base()
        {
            repository = repo;
        }

        public void SetCompareDate(DateTime dtm)
        {
            //For unit testing injection
            compareDate = dtm;
        }

        public Task<MHuntingRule> GetHuntingRuleById(string orgId, string ruleId)
        {
//Console.WriteLine("DEBUG_10");
            repository!.SetCustomOrgId(orgId);
            var result = repository!.GetHuntingRule(ruleId);
//Console.WriteLine("DEBUG_11");
            return result;
        }

        public MVHuntingRule? AddHuntingRule(string orgId, MHuntingRule huntingRule)
        {
            repository!.SetCustomOrgId(orgId);

            var r = new MVHuntingRule();
            var t = repository!.GetHuntingRuleByName(huntingRule.RuleName!);
            var m = t.Result;

            if (m != null)
            {
                r.Status = "DUPLICATE";
                r.Description = $"Rule name [{huntingRule.RuleName}] is duplicate";

                return r;
            }

            var result = repository!.AddHuntingRule(huntingRule);

            r.Status = "OK";
            r.Description = "Success";
            r.HuntingRule = result;

            return r;
        }

        public MVHuntingRule? DeleteHuntingRuleById(string orgId, string ruleId)
        {
            var r = new MVHuntingRule()
            {
                Status = "OK",
                Description = "Success"
            };

            if (!ServiceUtils.IsGuidValid(ruleId))
            {
                r.Status = "UUID_INVALID";
                r.Description = $"Rule ID [{ruleId}] format is invalid";

                return r;
            }

            repository!.SetCustomOrgId(orgId);
            var m = repository!.DeleteHuntingRuleById(ruleId);

            r.HuntingRule = m;
            if (m == null)
            {
                r.Status = "NOTFOUND";
                r.Description = $"Rule ID [{ruleId}] not found for the organization [{orgId}]";
            }

            return r;
        }

        public IEnumerable<MHuntingRule> GetHuntingRules(string orgId, VMHuntingRule param)
        {
            repository!.SetCustomOrgId(orgId);
            var result = repository!.GetHuntingRules(param);

            return result;
        }

        public MVHuntingRule? UpdateHuntingRuleById(string orgId, string huntingRuleId, MHuntingRule huntingRule)
        {
            var r = new MVHuntingRule()
            {
                Status = "OK",
                Description = "Success"
            };

            repository!.SetCustomOrgId(orgId);
            var result = repository!.UpdateHuntingRuleById(huntingRuleId, huntingRule);

            if (result == null)
            {
                r.Status = "NOTFOUND";
                r.Description = $"Rule ID [{huntingRuleId}] not found for the organization [{orgId}]";

                return r;
            }

            r.HuntingRule = result;
            return r;
        }

        public int GetHuntingRuleCount(string orgId, VMHuntingRule param)
        {
            repository!.SetCustomOrgId(orgId);
            var result = repository!.GetHuntingRuleCount(param);

            return result;
        }
    }
}
