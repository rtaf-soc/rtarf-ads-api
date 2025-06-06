using System.Diagnostics.CodeAnalysis;

namespace Its.Ads.Api.ViewsModels
{
    [ExcludeFromCodeCoverage]
    public class VMOrganizationUser : VMQueryBase
    {
        public string? FullTextSearch { get; set; }
    }
}
