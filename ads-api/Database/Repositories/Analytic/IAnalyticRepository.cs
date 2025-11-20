using Its.Ads.Api.Models;

namespace Its.Ads.Api.Database.Repositories
{
    public interface IAnalyticRepository
    {
        public void SetCustomOrgId(string customOrgId);

        public IEnumerable<Threat> GetThreatSeverities(int durationHour);
    }
}
