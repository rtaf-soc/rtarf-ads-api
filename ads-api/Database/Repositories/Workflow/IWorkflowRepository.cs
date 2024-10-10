using Its.Ads.Api.Models;

namespace Its.Ads.Api.Database.Repositories
{
    public interface IWorkflowRepository
    {
        public void SetCustomOrgId(string customOrgId);
        public MWorkFlow AddWorkflow(MWorkFlow workflow);
    }
}
