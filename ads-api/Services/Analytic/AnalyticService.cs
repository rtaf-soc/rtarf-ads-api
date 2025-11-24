using Its.Ads.Api.Models;
using Its.Ads.Api.Database.Repositories;


namespace Its.Ads.Api.Services
{
    public class AnalyticService : BaseService, IAnalyticService
    {
        private readonly IAnalyticRepository repository;

        public AnalyticService(IAnalyticRepository repo) : base()
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
            repository.SetCustomOrgId(orgId);
            var list = repository.GetThreatSeverities(24);

            if (list.Count() == 0)
            {
                list =
                [
                    new() { Serverity = "High (M)", Quantity = 1700 },
                    new() { Serverity = "Medium (M)", Quantity = 970 },
                    new() { Serverity = "Low (M)", Quantity = 800 }
                ];
            }

            return list;
        }

        public IEnumerable<Threat> GetThreatCategories(string orgId)
        {
            repository.SetCustomOrgId(orgId);
            var list = repository.GetThreatCategories(24);

            if (list.Count() == 0)
            {
                list =
                [
                    new() { ThreatName = "IP Sweep", Percentage = 35 },
                    new() { ThreatName = "Malwares", Percentage = 25 },
                    new() { ThreatName = "DDoS", Percentage = 20 },
                    new() { ThreatName = "Phising", Percentage = 15 },
                    new() { ThreatName = "Mocked#1", Percentage = 1 },
                    new() { ThreatName = "Mocked#2", Percentage = 1 },
                    new() { ThreatName = "Mocked#3", Percentage = 1 },
                    new() { ThreatName = "Mocked#4", Percentage = 2 },
                ];
            }

            return list; 
        }

        public IEnumerable<Threat> GetThreatAlerts(string orgId)
        {
            repository.SetCustomOrgId(orgId);
            var list = repository.GetThreatAlerts(24);

            if (list.Count() == 0)
            {
                list =
                [
                    new() { ThreatName = "THREAT #5", ThreatDetail = "8281034OCT24", IncidentID = "1" },
                    new() { ThreatName = "THREAT #4", ThreatDetail = "2809420CT24", IncidentID = "2" },
                    new() { ThreatName = "THREAT #3", ThreatDetail = "2805350CT24", IncidentID = "70" },
                    new() { ThreatName = "THREAT #2", ThreatDetail = "2801030CT24", IncidentID = "15" },
                    new() { ThreatName = "THREAT #1", ThreatDetail = "272315OCT24", IncidentID = "21" },
                ];
            }

            return list; 
        }

        public MitrSummary GetMitrStats(string orgId, DateTime? fromDate, DateTime? toDate)
        {
            if ((!fromDate.HasValue) && (!toDate.HasValue))
            {
                fromDate = DateTime.UtcNow.AddDays(-30);
                toDate = DateTime.UtcNow;
            }

            var summary = new MitrSummary();
            repository.SetCustomOrgId(orgId);

            var serverities = repository.GetMitrSeveritieStats(fromDate, toDate);
            if (serverities.Count() == 0)
            {
                summary.SeveritySummary =
                [
                    new() { SeverityName = "Critical", Quantity = 234 },
                    new() { SeverityName = "High", Quantity = 200 },
                    new() { SeverityName = "Medium", Quantity = 123 },
                    new() { SeverityName = "Low", Quantity = 100 },
                ];
            }
            else
            {
                summary.SeveritySummary = [.. serverities];
            }

            var tactics = repository.GetMitrTacticTechniqueStats(fromDate, toDate);
            if (tactics.Count() == 0)
            {
                summary.TacticTechniqueSummary =
                [
                    new() { TacticName = "Reconnaissance", TacticId = "TA0043", TechniqueId = "T1592", LastSeen = DateTime.UtcNow.AddDays(-1), Quantity = 150 },
                    new() { TacticName = "Reconnaissance", TacticId = "TA0043", TechniqueId = "T1594", LastSeen = DateTime.UtcNow.AddDays(-2), Quantity = 120 },
                    new() { TacticName = "Reconnaissance", TacticId = "TA0043", TechniqueId = "T1589", LastSeen = DateTime.UtcNow.AddDays(-3), Quantity = 90 },
                    new() { TacticName = "Reconnaissance", TacticId = "TA0043", TechniqueId = "T1591", LastSeen = DateTime.UtcNow.AddDays(-4), Quantity = 60 },
                ];
            }
            else
            {
                summary.TacticTechniqueSummary = [.. tactics];
            }

            summary.TotalEvent = repository.GetMitrEventCount(fromDate, toDate);
            summary.TotalTechnique = repository.GetMitrTechniqueCount(fromDate, toDate);

            return summary;
        }
    }
}
