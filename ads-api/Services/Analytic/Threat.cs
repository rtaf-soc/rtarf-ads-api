namespace Its.Ads.Api.Models
{
    public class Threat
    {
        public string ThreatName { get; set; }
        public string ThreatDetail { get; set; }
        public int Quantity { get; set; }
        public double Percentage { get; set; }

        public Threat()
        {
            Quantity = 0;
            Percentage = 0;
            ThreatName = "";
            ThreatDetail = "";
        }
    }
}
