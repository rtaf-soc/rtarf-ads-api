using Its.Ads.Api.Models;

namespace Its.Ads.Api.Database.Repositories
{
    public interface IAnalyticRepository
    {
        public void SetCustomOrgId(string customOrgId);

        public IEnumerable<Threat> GetThreatSeverities(int durationHour);
        public IEnumerable<Threat> GetThreatCategories(int durationHour);
        public IEnumerable<Threat> GetThreatAlerts(int durationHour);
        public IEnumerable<MitrStat> GetMitrSeveritieStats(DateTime? fromDate, DateTime? toDate);
        public IEnumerable<MitrStat> GetMitrTacticTechniqueStats(DateTime? fromDate, DateTime? toDate);
        public long GetMitrEventCount(DateTime? fromDate, DateTime? toDate);
        public long GetMitrTechniqueCount(DateTime? fromDate, DateTime? toDate);
    }
}
