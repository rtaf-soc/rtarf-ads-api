namespace Its.Ads.Api.Models
{
    public class MitrStat
    {
        public string TacticName { get; set; }
        public string TacticId { get; set; }
        public string TechniqueName { get; set; }
        public string TechniqueId { get; set; }
        public string SeverityName { get; set; }
        public long Quantity { get; set; }
        public DateTime? LastSeen { get; set; }

        public MitrStat()
        {
            Quantity = 0;
            TacticName = "";
            TacticId = "";
            TechniqueName = "";
            TechniqueId = "";
            SeverityName = "";
        }
    }
}
