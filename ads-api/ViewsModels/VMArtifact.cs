using System.Diagnostics.CodeAnalysis;

namespace Its.Ads.Api.ViewsModels
{
    [ExcludeFromCodeCoverage]
    public class VMArtifact : VMQueryBase
    {
        public int? ArtifactType { get; set; }
        public string? ArtifactCode { get; set; }
        public string? FullTextSearch { get; set; }
    }
}
