using System.Diagnostics.CodeAnalysis;

namespace Its.Ads.Api.ViewsModels
{
    [ExcludeFromCodeCoverage]
    public class VMIocHost : VMQueryBase
    {
        public int? BlacklistType { get; set; }
        public string? IocEndpoint { get; set; }
        public string? IocType { get; set; }
        public string? FullTextSearch { get; set; }
    }
}
