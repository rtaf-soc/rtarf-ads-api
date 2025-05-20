using System.Diagnostics.CodeAnalysis;

namespace Its.Ads.Api.ViewsModels
{
    [ExcludeFromCodeCoverage]
    public class VMDevice : VMQueryBase
    {
        public string? FullTextSearch { get; set; }
    }
}
