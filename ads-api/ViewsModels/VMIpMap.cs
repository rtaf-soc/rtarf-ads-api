using System.Diagnostics.CodeAnalysis;

namespace Its.Ads.Api.ViewsModels
{
    [ExcludeFromCodeCoverage]
    public class VMIpMap : VMQueryBase
    {
        public string? Cidr { get; set; }
        public string? Zone { get; set; }
        public string? FullTextSearch { get; set; }
    }
}
