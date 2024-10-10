using System.Diagnostics.CodeAnalysis;
using Its.Ads.Api.Models;

namespace Its.Ads.Api.ModelsViews
{
    [ExcludeFromCodeCoverage]
    public class MVOrganization
    {
        public string? Status { get; set; }
        public string? Description { get; set; }
        public MOrganization? Organization { get; set; }
    }
}
