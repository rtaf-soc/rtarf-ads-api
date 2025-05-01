using Its.Ads.Api.Models;
using Its.Ads.Api.ModelsViews;
using Its.Ads.Api.ViewsModels;

namespace Its.Ads.Api.Services
{
    public interface IHuntingRuleService
    {
        public Task<MHuntingRule> GetHuntingRuleById(string orgId, string ruleId);
        public MVHuntingRule? AddHuntingRule(string orgId, MHuntingRule huntingRule);
        public MVHuntingRule? DeleteHuntingRuleById(string orgId, string ruleId);
        public IEnumerable<MHuntingRule> GetHuntingRules(string orgId, VMHuntingRule param);
        public int GetHuntingRuleCount(string orgId, VMHuntingRule param);
        public MVHuntingRule? UpdateHuntingRuleById(string orgId, string huntingRuleId, MHuntingRule huntingRule);
    }
}
