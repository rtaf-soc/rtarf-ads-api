using System.Diagnostics.CodeAnalysis;
using Its.Ads.Api.Models;

namespace Its.Ads.Api.ModelsViews
{
    [ExcludeFromCodeCoverage]
    public class MVIocHost
    {
        public string? Status { get; set; }
        public string? Description { get; set; }
        public MIocHost? IocHost { get; set; }
    }
}
