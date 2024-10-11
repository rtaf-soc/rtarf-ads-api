using Its.Ads.Api.Models;
using Its.Ads.Api.ViewsModels;

namespace Its.Ads.Api.Database.Repositories
{
    public interface IArtifactRepository
    {
        public void SetCustomOrgId(string customOrgId);
        public MArtifact AddArtifact(MArtifact artifac);
        public int GetArtifactCount(VMArtifact param);
        public IEnumerable<MArtifact> GetArtifacts(VMArtifact param);
        public MArtifact GetArtifactById(string artifactId);
        public MArtifact GetArtifactByCode(string artifactCode);
        public MArtifact? DeleteArtifactById(string artifactId);
        public bool IsArtifactCodeExist(string artifactCode);
    }
}
