using System.Diagnostics.CodeAnalysis;

namespace Its.Ads.Api.ViewsModels
{
    [ExcludeFromCodeCoverage]
    public class VMApiKey : VMQueryBase
    {
        public string? FullTextSearch { get; set; }
    }
}
