using LinqKit;
using Its.Ads.Api.Models;
using Its.Ads.Api.ViewsModels;

namespace Its.Ads.Api.Database.Repositories
{
    public class ArtifactRepository : BaseRepository, IArtifactRepository
    {
        public ArtifactRepository(IDataContext ctx)
        {
            context = ctx;
        }

        public MArtifact AddArtifact(MArtifact artifact)
        {
            artifact.ArtifactId = Guid.NewGuid();
            artifact.CreatedDate = DateTime.UtcNow;
            artifact.OrgId = orgId;

            context!.Artifacts!.Add(artifact);
            context.SaveChanges();

            return artifact;
        }

        private ExpressionStarter<MArtifact> ArtifactPredicate(VMArtifact param)
        {
            var pd = PredicateBuilder.New<MArtifact>();

            pd = pd.And(p => p.OrgId!.Equals(orgId));

            if ((param.ArtifactType != null) && (param.ArtifactType >= 0))
            {
                pd = pd.And(p => p.ArtifactType!.Equals(param.ArtifactType));
            }

            if ((param.FullTextSearch != "") && (param.FullTextSearch != null))
            {
                var fullTextPd = PredicateBuilder.New<MArtifact>();
                fullTextPd = fullTextPd.Or(p => p.ArtifactCode!.Contains(param.FullTextSearch));

                pd = pd.And(fullTextPd);
            }

            return pd;
        }

        public int GetArtifactCount(VMArtifact param)
        {
            var predicate = ArtifactPredicate(param);
            var cnt = context!.Artifacts!.Where(predicate).Count();

            return cnt;
        }

        public IEnumerable<MArtifact> GetArtifacts(VMArtifact param)
        {
            var limit = 0;
            var offset = 0;

            //Param will never be null
            if (param.Offset > 0)
            {
                //Convert to zero base
                offset = param.Offset-1;
            }

            if (param.Limit > 0)
            {
                limit = param.Limit;
            }

            var predicate = ArtifactPredicate(param!);
            var arr = context!.Artifacts!.Where(predicate)
                .OrderByDescending(e => e.ArtifactCode)
                .Skip(offset)
                .Take(limit)
                .ToList();

            return arr;
        }

        public MArtifact GetArtifactById(string artifactId)
        {
            var u = context!.Artifacts!.Where(p => p!.ArtifactId!.Equals(artifactId) && p!.OrgId!.Equals(orgId)).FirstOrDefault();
            return u!;
        }

        public bool IsArtifactCodeExist(string artifactCode)
        {
            var cnt = context!.Artifacts!.Where(p => p!.ArtifactCode!.Equals(artifactCode) && p!.OrgId!.Equals(orgId)).Count();
            return cnt >= 1;
        }

        public MArtifact? DeleteArtifactById(string artifactId)
        {
            Guid id = Guid.Parse(artifactId);

            var r = context!.Artifacts!.Where(x => x.OrgId!.Equals(orgId) && x.ArtifactId.Equals(id)).FirstOrDefault();
            if (r != null)
            {
                context!.Artifacts!.Remove(r);
                context.SaveChanges();
            }

            return r;
        }
    }
}