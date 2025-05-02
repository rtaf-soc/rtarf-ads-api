using System.Diagnostics.CodeAnalysis;

namespace Its.Ads.Api.ViewsModels
{
    [ExcludeFromCodeCoverage]
    public class VMHuntingRule : VMQueryBase
    {
        public string? FullTextSearch { get; set; }
        public string? RefType { get; set; }
    }
}
