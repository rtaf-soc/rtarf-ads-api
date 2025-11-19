using Its.Ads.Api.Models;
using Its.Ads.Api.ModelsViews;
using Its.Ads.Api.ViewsModels;

namespace Its.Ads.Api.Services
{
    public interface IAnalyticService
    {
        public DefconStatus GetDefConStatus(string orgId);
        public IEnumerable<ReconStatus> GetReconCountries(string orgId);
        public IEnumerable<Threat> GetThreatDistributions(string orgId);
        public IEnumerable<Threat> GetThreatAlerts(string orgId);
    }
}
