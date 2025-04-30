using Its.Ads.Api.Models;

namespace Its.Ads.Api.Database.Repositories
{
    public interface IHuntingRuleRepository
    {
        public void SetCustomOrgId(string customOrgId);
        public Task<MHuntingRule> GetHuntingRule(string ruleId);
        public MHuntingRule AddHuntingRule(MHuntingRule huntingRule);
        public MHuntingRule? DeleteHuntingRuleById(string ruleId);
        public IEnumerable<MHuntingRule> GetHuntingRules();
    }
}
