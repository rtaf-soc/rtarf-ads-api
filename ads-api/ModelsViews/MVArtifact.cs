using System.Diagnostics.CodeAnalysis;
using Its.Ads.Api.Models;

namespace Its.Ads.Api.ModelsViews
{
    [ExcludeFromCodeCoverage]
    public class MVArtifact
    {
        public string? Status { get; set; }
        public string? Description { get; set; }
        public MArtifact? Artifact { get; set; }
    }
}
