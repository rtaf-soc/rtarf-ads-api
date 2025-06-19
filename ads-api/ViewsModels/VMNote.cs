using System.Diagnostics.CodeAnalysis;

namespace Its.Ads.Api.ViewsModels
{
    [ExcludeFromCodeCoverage]
    public class VMNote : VMQueryBase
    {
        public string? FullTextSearch { get; set; }
    }
}
