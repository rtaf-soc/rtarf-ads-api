using System.Diagnostics.CodeAnalysis;
using Its.Ads.Api.Models;

namespace Its.Ads.Api.ModelsViews
{
    [ExcludeFromCodeCoverage]
    public class MVBlacklist
    {
        public string? Status { get; set; }
        public string? Description { get; set; }
        public MBlacklist? Blacklist { get; set; }
    }
}
