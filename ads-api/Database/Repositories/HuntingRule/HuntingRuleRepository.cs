using Its.Ads.Api.Models;
using Its.Ads.Api.ViewsModels;
using LinqKit;
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
            Guid id = Guid.Parse(ruleId);
            var result = context!.HuntingRules!.Where(x => x.OrgId!.Equals(orgId) && x.RuleId!.Equals(id)).FirstOrDefaultAsync();

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

        public IEnumerable<MHuntingRule> GetHuntingRules(VMHuntingRule param)
        {
            var limit = 0;
            var offset = 0;

            //Param will never be null
            if (param.Offset > 0)
            {
                //Convert to zero base
                offset = param.Offset-1;
            }

            if (param.Limit > 0)
            {
                limit = param.Limit;
            }

            var predicate = HuntingRulePredicate(param!);
            var arr = context!.HuntingRules!.Where(predicate)
                .OrderByDescending(e => e.RuleCreatedDate)
                .Skip(offset)
                .Take(limit)
                .ToList();

            return arr;
        }

        private ExpressionStarter<MHuntingRule> HuntingRulePredicate(VMHuntingRule param)
        {
            var pd = PredicateBuilder.New<MHuntingRule>();

            pd = pd.And(p => p.OrgId!.Equals(orgId));

            if ((param.FullTextSearch != "") && (param.FullTextSearch != null))
            {
                var fullTextPd = PredicateBuilder.New<MHuntingRule>();
                fullTextPd = fullTextPd.Or(p => p.RuleName!.Contains(param.FullTextSearch));
                fullTextPd = fullTextPd.Or(p => p.RuleDescription!.Contains(param.FullTextSearch));
                fullTextPd = fullTextPd.Or(p => p.Tags!.Contains(param.FullTextSearch));
                fullTextPd = fullTextPd.Or(p => p.RefUrl!.Contains(param.FullTextSearch));

                pd = pd.And(fullTextPd);
            }

            if ((param.RefType != "") && (param.RefType != null))
            {
                var fullTextPd = PredicateBuilder.New<MHuntingRule>();
                fullTextPd = fullTextPd.Or(p => p.RefType!.Equals(param.RefType));

                pd = pd.And(fullTextPd);
            }

            return pd;
        }

        public int GetHuntingRuleCount(VMHuntingRule param)
        {
            var predicate = HuntingRulePredicate(param);
            var cnt = context!.HuntingRules!.Where(predicate).Count();

            return cnt;
        }

        public Task<MHuntingRule> GetHuntingRuleByName(string ruleName)
        {
            var result = context!.HuntingRules!.Where(x => x.OrgId!.Equals(orgId) && x.RuleName!.Equals(ruleName)).FirstOrDefaultAsync();
            return result!;
        }

        public MHuntingRule? UpdateHuntingRuleById(string huntingRuleId, MHuntingRule huntingRule)
        {
            Guid id = Guid.Parse(huntingRuleId);
            var result = context!.HuntingRules!.Where(x => x.OrgId!.Equals(orgId) && x.RuleId!.Equals(id)).FirstOrDefault();

            if (result != null)
            {
                result.RuleDescription = huntingRule.RuleDescription;
                result.RuleDefinition = huntingRule.RuleDefinition;
                result.RefUrl = huntingRule.RefUrl;
                result.Tags = huntingRule.Tags;

                context!.SaveChanges();
            }

            return result!;
        }
    }
}