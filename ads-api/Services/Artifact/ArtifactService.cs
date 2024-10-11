using Its.Ads.Api.Models;
using Its.Ads.Api.ModelsViews;
using Its.Ads.Api.Database.Repositories;
using Its.Ads.Api.Utils;
using Its.Ads.Api.ViewsModels;

namespace Its.Ads.Api.Services
{
    public class ArtifactService : BaseService, IArtifactService
    {
        private readonly IArtifactRepository? repository = null;

        public ArtifactService(IArtifactRepository repo) : base()
        {
            repository = repo;
        }

        public MArtifact GetArtifactById(string orgId, string artifactId)
        {
            repository!.SetCustomOrgId(orgId);
            var result = repository!.GetArtifactById(artifactId);

            return result;
        }

        public MVArtifact? AddArtifact(string orgId, MArtifact artifact)
        {
            repository!.SetCustomOrgId(orgId);

            var r = new MVArtifact();

            var isExist = repository!.IsArtifactCodeExist(artifact.ArtifactCode!);

            if (isExist)
            {
                r.Status = "DUPLICATE";
                r.Description = $"Artifact code [{artifact.ArtifactCode}] is duplicate";

                return r;
            }

            var result = repository!.AddArtifact(artifact);

            r.Status = "OK";
            r.Description = "Success";
            r.Artifact = result;

            return r;
        }

        public MVArtifact? DeleteArtifactById(string orgId, string artifactId)
        {
            var r = new MVArtifact()
            {
                Status = "OK",
                Description = "Success"
            };

            if (!ServiceUtils.IsGuidValid(artifactId))
            {
                r.Status = "UUID_INVALID";
                r.Description = $"Artifact ID [{artifactId}] format is invalid";

                return r;
            }

            repository!.SetCustomOrgId(orgId);
            var m = repository!.DeleteArtifactById(artifactId);

            r.Artifact = m;
            if (m == null)
            {
                r.Status = "NOTFOUND";
                r.Description = $"Artifact ID [{artifactId}] not found for the organization [{orgId}]";
            }

            return r;
        }

        public IEnumerable<MArtifact> GetArtifacts(string orgId, VMArtifact param)
        {
            repository!.SetCustomOrgId(orgId);
            var result = repository!.GetArtifacts(param);

            return result;
        }

        public int GetArtifactCount(string orgId, VMArtifact param)
        {
            repository!.SetCustomOrgId(orgId);
            var result = repository!.GetArtifactCount(param);

            return result;
        }
    }
}
