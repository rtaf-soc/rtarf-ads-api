using Its.Ads.Api.Models;
using Its.Ads.Api.ViewsModels;

namespace Its.Ads.Api.Database.Repositories
{
    public interface IHuntingRuleRepository
    {
        public void SetCustomOrgId(string customOrgId);
        public Task<MHuntingRule> GetHuntingRule(string ruleId);
        public Task<MHuntingRule> GetHuntingRuleLuceneQueryById(string ruleId);
        public Task<MHuntingRule> GetHuntingRuleByName(string ruleName);
        public MHuntingRule AddHuntingRule(MHuntingRule huntingRule);
        public MHuntingRule? DeleteHuntingRuleById(string ruleId);
        public IEnumerable<MHuntingRule> GetHuntingRules(VMHuntingRule param);
        public int GetHuntingRuleCount(VMHuntingRule param);
        public MHuntingRule? UpdateHuntingRuleById(string huntingRuleId, MHuntingRule huntingRule);
    }
}
