using Its.Ads.Api.Models;
using Its.Ads.Api.ModelsViews;
using Its.Ads.Api.Database.Repositories;
using Its.Ads.Api.Utils;
using Its.Ads.Api.ViewsModels;

namespace Its.Ads.Api.Services
{
    public class AnalyticService : BaseService, IAnalyticService
    {
        private readonly INodeRepository? repository = null;

        public AnalyticService(INodeRepository repo) : base()
        {
            repository = repo;
        }

        public DefconStatus GetDefConStatus(string orgId)
        {
            var status = new DefconStatus()
            {
                Level = 1,
            };

            return status;
        }

        public IEnumerable<ReconStatus> GetReconCountries(string orgId)
        {
            var list = new List<ReconStatus>()
            {
                new() { Country = "Canbodia", Quantity = 1700 },
                new() { Country = "North Korea", Quantity = 970 },
                new() { Country = "China", Quantity = 800 },
                new() { Country = "Iran", Quantity = 505 },
                new() { Country = "Thailand", Quantity = 345 },
            };

            return list;
        }

        public IEnumerable<Threat> GetThreatSeverities(string orgId)
        {
            var list = new List<Threat>()
            {
                new() { Serverity = "High", Quantity = 1700 },
                new() { Serverity = "Medium", Quantity = 970 },
                new() { Serverity = "Low", Quantity = 800 }
            };

            return list;
        }

        public IEnumerable<Threat> GetThreatDistributions(string orgId)
        {
            var list = new List<Threat>()
            {
                new() { ThreatName = "IP Sweep", Percentage = 35 },
                new() { ThreatName = "Malwares", Percentage = 25 },
                new() { ThreatName = "DDoS", Percentage = 20 },
                new() { ThreatName = "Phising", Percentage = 15 },
                new() { ThreatName = "Others", Percentage = 5 },
            };

            return list; 
        }

        public IEnumerable<Threat> GetThreatAlerts(string orgId)
        {
            var list = new List<Threat>()
            {
                new() { ThreatName = "THREAT #5", ThreatDetail = "8281034OCT24" },
                new() { ThreatName = "THREAT #4", ThreatDetail = "2809420CT24" },
                new() { ThreatName = "THREAT #3", ThreatDetail = "2805350CT24" },
                new() { ThreatName = "THREAT #2", ThreatDetail = "2801030CT24" },
                new() { ThreatName = "THREAT #1", ThreatDetail = "272315OCT24" },
            };

            return list; 
        }
    }
}
