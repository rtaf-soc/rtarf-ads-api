using Its.Ads.Api.Models;
using Its.Ads.Api.ModelsViews;

namespace Its.Ads.Api.Services
{
    public interface IWorkflowService
    {
        public MVWorkflow? AddWorkflow(string orgId, MWorkFlow workflow);
    }
}
