using Its.Ads.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Its.Ads.Api.Database.Repositories
{
    public class AnalyticRepository : BaseRepository, IAnalyticRepository
    {
        public AnalyticRepository(IDataContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<MitrStat> GetMitrSeveritieStats(DateTime? fromDate, DateTime? toDate)
        {
            var query = context!.LogAggregates!
                .Where(x =>
                    x.OrgId == orgId &&
                    x.CustomField8 != null &&
                    x.CustomField8 != "" &&
                    x.AggregatorType == "aggr_crowdstrike_incident_mitre_v1");

            // >= fromDate
            if (fromDate.HasValue)
            {
                query = query.Where(x => x.EventDate >= fromDate.Value);
            }

            // <= toDate
            if (toDate.HasValue)
            {
                query = query.Where(x => x.EventDate <= toDate.Value);
            }

            var arr = query
                .GroupBy(x => x.CustomField4)
                .Select(g => new MitrStat
                {
                    SeverityName = g.Key!,
                    Quantity = g.Sum(x => x.EventCount ?? 0)
                })
                .OrderByDescending(x => x.Quantity)
                .ToList();

            return arr;
        }

        public IEnumerable<MitrStat> GetMitrTacticTechniqueStats(DateTime? fromDate, DateTime? toDate)
        {
            var query = context!.LogAggregates!
                .Where(x =>
                    x.OrgId == orgId &&
                    x.CustomField8 != null &&
                    x.CustomField8 != "" &&
                    x.AggregatorType == "aggr_crowdstrike_incident_mitre_v1");

            // >= fromDate
            if (fromDate.HasValue)
            {
                query = query.Where(x => x.EventDate >= fromDate.Value);
            }

            // <= toDate
            if (toDate.HasValue)
            {
                query = query.Where(x => x.EventDate <= toDate.Value);
            }

            var arr = query
                .GroupBy(x => new { x.CustomField7, x.CustomField8, x.CustomField12 })
                .Select(g => new MitrStat
                {
                    TacticId = g.Key.CustomField8!,
                    TacticName = g.Key.CustomField7!,
                    TechniqueId = g.Key.CustomField12!,
                    Quantity = g.Sum(x => x.EventCount ?? 0),
                    LastSeen = g.Max(x => x.EventDate)
                })
                .OrderBy(x => x.TacticId)
                .ThenBy(x => x.TechniqueId)
                .ToList();

            return arr;
        }

        public long GetMitrEventCount(DateTime? fromDate, DateTime? toDate)
        {
            var query = context!.LogAggregates!
                .Where(x =>
                    x.OrgId == orgId &&
                    x.CustomField8 != null &&
                    x.CustomField8 != "" &&
                    x.AggregatorType == "aggr_crowdstrike_incident_mitre_v1");

            // >= fromDate
            if (fromDate.HasValue)
            {
                query = query.Where(x => x.EventDate >= fromDate.Value);
            }

            // <= toDate
            if (toDate.HasValue)
            {
                query = query.Where(x => x.EventDate <= toDate.Value);
            }

            var count = query
                .Sum(x => x.EventCount ?? 0);

            return count;
        }

        public long GetMitrTechniqueCount(DateTime? fromDate, DateTime? toDate)
        {
            var query = context!.LogAggregates!
                .Where(x =>
                    x.OrgId == orgId &&
                    x.CustomField8 != null &&
                    x.CustomField8 != "" &&
                    x.AggregatorType == "aggr_crowdstrike_incident_mitre_v1");

            // จากวันที่ (>= fromDate)
            if (fromDate.HasValue)
            {
                query = query.Where(x => x.EventDate >= fromDate.Value);
            }

            // ถึงวันที่ (<= toDate)
            if (toDate.HasValue)
            {
                query = query.Where(x => x.EventDate <= toDate.Value);
            }

            var count = query
                .Select(x => x.CustomField11)
                .Distinct()
                .Count();

            return count;
        }

        public IEnumerable<Threat> GetThreatAlerts(int durationHour)
        {
            var cutoff = DateTime.UtcNow.AddHours(-durationHour);

            var arr = context!.LogAggregates!
                .Where(x =>
                    x.OrgId == orgId &&
                    x.CustomField4 != null &&
                    x.CustomField4 != "" &&
                    x.AggregatorType == "aggr_xsiam_incident_v1" &&
                    !x.CustomField4.StartsWith("[") &&
                    x.CustomField1 == "high" &&
                    x.EventDate > cutoff)
                .Select(g => new Threat
                {
                    ThreatName = g.CustomField4!,
                    ThreatDetail = g.CustomField5!,
                    Serverity = string.IsNullOrEmpty(g.CustomField7) ? "0" : g.CustomField7,
                    IncidentID = g.CustomField2!,
                })
                .OrderByDescending(x => Convert.ToInt32(x.Serverity))
                .ToList();

            return arr;
        }

        public IEnumerable<Threat> GetThreatCategories(int durationHour)
        {
            var cutoff = DateTime.UtcNow.AddHours(-durationHour);

            var arr = context!.LogAggregates!
                .Where(x =>
                    x.OrgId == orgId &&
                    x.CustomField4 != null &&
                    x.CustomField4 != "" &&
                    x.AggregatorType == "aggr_xsiam_incident_v1" &&
                    !x.CustomField4.StartsWith("[") &&
                    x.EventDate > cutoff)
                .GroupBy(x => x.CustomField4)
                .Select(g => new Threat
                {
                    ThreatName = g.Key!,
                    Quantity = g.Sum(x => x.EventCount ?? 0)
                })
                .OrderByDescending(x => x.Quantity)
                .ToList();

            return arr;
        }

        public IEnumerable<Threat> GetThreatSeverities(int durationHour)
        {
            var cutoff = DateTime.UtcNow.AddHours(-durationHour);

            var arr = context!.LogAggregates!
                .Where(x =>
                    x.OrgId == orgId &&
                    x.CustomField1 != null &&
                    x.CustomField1 != "" &&
                    x.AggregatorType == "aggr_xsiam_incident_v1" &&
                    x.EventDate > cutoff)
                .GroupBy(x => x.CustomField1)
                .Select(g => new Threat
                {
                    Serverity = g.Key,
                    Quantity = g.Sum(x => x.EventCount ?? 0)
                })
                .OrderByDescending(x => x.Quantity)
                .ToList();

            return arr;
        }
    }
}
