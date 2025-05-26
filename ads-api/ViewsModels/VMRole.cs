using System.Diagnostics.CodeAnalysis;

namespace Its.Ads.Api.ViewsModels
{
    [ExcludeFromCodeCoverage]
    public class VMRole : VMQueryBase
    {
        public string? FullTextSearch { get; set; }
    }
}
