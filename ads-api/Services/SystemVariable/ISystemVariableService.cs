using Its.Ads.Api.Models;
using Its.Ads.Api.ModelsViews;
using Its.Ads.Api.ViewsModels;

namespace Its.Ads.Api.Services
{
    public interface ISystemVariableService
    {
        public MSystemVariable GetSystemVariableById(string orgId, string systemVariableId);
        public MVSystemVariable? AddSystemVariable(string orgId, MSystemVariable systemVariable);
        public MVSystemVariable? DeleteSystemVariableById(string orgId, string systemVariableId);
        public IEnumerable<MSystemVariable> GetSystemVariables(string orgId, VMSystemVariable param);
        public int GetSystemVariableCount(string orgId, VMSystemVariable param);
        public MSystemVariable GetSystemVariableByName(string orgId, string systemVariableName);
        public MVSystemVariable? UpdateSystemVariableById(string orgId, string systemVariableId, MSystemVariable systemVariable);
    }
}
