using LinqKit;
using Its.Ads.Api.Models;
using Its.Ads.Api.ViewsModels;
using NetTopologySuite.Geometries;
using Confluent.Kafka;

namespace Its.Ads.Api.Database.Repositories
{
    public class AnalyticRepository : BaseRepository, IAnalyticRepository
    {
        public AnalyticRepository(IDataContext ctx)
        {
            context = ctx;
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
