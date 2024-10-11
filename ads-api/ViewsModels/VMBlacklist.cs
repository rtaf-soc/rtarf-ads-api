using System.Diagnostics.CodeAnalysis;

namespace Its.Ads.Api.ViewsModels
{
    [ExcludeFromCodeCoverage]
    public class VMBlacklist : VMQueryBase
    {
        public int? BlacklistType { get; set; }
        public string? BlacklistCode { get; set; }
        public string? FullTextSearch { get; set; }
    }
}
