using System.Diagnostics.CodeAnalysis;
using Its.Ads.Api.Models;

namespace Its.Ads.Api.ModelsViews
{
    [ExcludeFromCodeCoverage]
    public class MVDevice
    {
        public string? Status { get; set; }
        public string? Description { get; set; }
        public MDevice? Device { get; set; }
    }
}
