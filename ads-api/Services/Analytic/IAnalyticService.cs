using Its.Ads.Api.Models;

namespace Its.Ads.Api.Services
{
    public interface IAnalyticService
    {
        public DefconStatus GetDefConStatus(string orgId);
        public IEnumerable<ReconStatus> GetReconCountries(string orgId);
        public IEnumerable<Threat> GetThreatCategories(string orgId);
        public IEnumerable<Threat> GetThreatAlerts(string orgId);
        public IEnumerable<Threat> GetThreatSeverities(string orgId);
    }
}
