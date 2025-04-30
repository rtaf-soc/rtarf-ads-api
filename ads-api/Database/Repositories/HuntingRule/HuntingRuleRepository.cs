using Its.Ads.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Its.Ads.Api.Database.Repositories
{
    public class HuntingRuleRepository : BaseRepository, IHuntingRuleRepository
    {
        public HuntingRuleRepository(IDataContext ctx)
        {
            context = ctx;
        }

        public Task<MHuntingRule> GetHuntingRule(string ruleId)
        {
            var result = context!.HuntingRules!.Where(x => x.OrgId!.Equals(orgId) && x.RuleId!.Equals(ruleId)).FirstOrDefaultAsync();
            return result!;
        }

        public MHuntingRule AddHuntingRule(MHuntingRule huntingRule)
        {
            huntingRule.RuleId = Guid.NewGuid();
            huntingRule.RuleCreatedDate = DateTime.UtcNow;
            huntingRule.OrgId = orgId;

            context!.HuntingRules!.Add(huntingRule);
            context.SaveChanges();

            return huntingRule;
        }

        public MHuntingRule? DeleteHuntingRuleById(string ruleId)
        {
            Guid id = Guid.Parse(ruleId);

            var r = context!.HuntingRules!.Where(x => x.OrgId!.Equals(orgId) && x.RuleId.Equals(id)).FirstOrDefault();
            if (r != null)
            {
                context!.HuntingRules!.Remove(r);
                context.SaveChanges();
            }

            return r;
        }

        public IEnumerable<MHuntingRule> GetHuntingRules()
        {
            var arr = context!.HuntingRules!.Where(x => x.OrgId!.Equals(orgId)).ToList();
            return arr;
        }
    }
}