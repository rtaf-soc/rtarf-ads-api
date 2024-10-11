using Its.Ads.Api.Models;
using Its.Ads.Api.ModelsViews;
using Its.Ads.Api.ViewsModels;

namespace Its.Ads.Api.Services
{
    public interface IArtifactService
    {
        public MArtifact GetArtifactById(string orgId, string artifactId);
        public MVArtifact? AddArtifact(string orgId, MArtifact artifact);
        public MVArtifact? DeleteArtifactById(string orgId, string artifactId);
        public IEnumerable<MArtifact> GetArtifacts(string orgId, VMArtifact param);
        public int GetArtifactCount(string orgId, VMArtifact param);
        public MArtifact GetArtifactByCode(string orgId, string artifactCode);
    }
}
