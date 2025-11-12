using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using NetTopologySuite.Geometries;

namespace Its.Ads.Api.Models
{
    [ExcludeFromCodeCoverage]
    public class MKeyValue
    {
        public string? Name { get; set; }
        public string? Value { get; set; }

        public MKeyValue()
        {
        }
    }
}
