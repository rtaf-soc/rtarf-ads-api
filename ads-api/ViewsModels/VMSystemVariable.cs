using System.Diagnostics.CodeAnalysis;

namespace Its.Ads.Api.ViewsModels
{
    [ExcludeFromCodeCoverage]
    public class VMSystemVariable : VMQueryBase
    {
        public string? FullTextSearch { get; set; }
    }
}
