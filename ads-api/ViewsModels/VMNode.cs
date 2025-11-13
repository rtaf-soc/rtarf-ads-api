using System.Diagnostics.CodeAnalysis;

namespace Its.Ads.Api.ViewsModels
{
    [ExcludeFromCodeCoverage]
    public class VMNode : VMQueryBase
    {
        public string? FullTextSearch { get; set; }
        public string? Layer { get; set; }
        public string? Type { get; set; }
    }
}
