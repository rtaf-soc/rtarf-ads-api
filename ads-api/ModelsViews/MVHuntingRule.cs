using System.Diagnostics.CodeAnalysis;
using Its.Ads.Api.Models;

namespace Its.Ads.Api.ModelsViews
{
    [ExcludeFromCodeCoverage]
    public class MVHuntingRule
    {
        public string? Status { get; set; }
        public string? Description { get; set; }
        public MHuntingRule? HuntingRule { get; set; }
    }
}
