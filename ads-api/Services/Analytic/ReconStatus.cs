namespace Its.Ads.Api.Models
{
    public class ReconStatus
    {
        public string Country { get; set; }
        public int Quantity { get; set; }

        public ReconStatus()
        {
            Quantity = 0;
            Country = "";
        }
    }
}
