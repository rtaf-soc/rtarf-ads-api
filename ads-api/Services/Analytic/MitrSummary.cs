namespace Its.Ads.Api.Models
{
    public class MitrSummary
    {
        public long TotalEvent { get; set; }
        public long TotalTechnique { get; set; }

        public List<MitrStat> SeveritySummary { get; set; }
        public List<MitrStat> CalculatedSeveritySummary { get; set; }
        public List<MitrStat> TacticTechniqueSummary { get; set; }

        public MitrSummary()
        {
            SeveritySummary = [];
            TacticTechniqueSummary = [];
            CalculatedSeveritySummary = [];
        }
    }
}
