using Its.Ads.Api.Models;
using Its.Ads.Api.ViewsModels;

namespace Its.Ads.Api.Database.Repositories
{
    public interface INodeRepository
    {
        public void SetCustomOrgId(string customOrgId);
        public MNode AddNode(MNode node);
        public int GetNodeCount(VMNode param);
        public IEnumerable<MNode> GetNodes(VMNode param);
        public MNode GetNodeById(string nodeId);
        public MNode? DeleteNodeById(string nodeId);
        public MNode? DeleteNodeAndLinkById(string nodeId);

        public MNode? UpdateNodeById(string nodeId, MNode node);

        public MNodeLink AddLink(MNodeLink link);
        public IEnumerable<MNodeLink> GetNodeLinks(string nodeId);
        public MNodeLink? DeleteLinkById(string linkId);
        public MNodeLink? UpdateLinkById(string linkId, MNodeLink link);

        public IEnumerable<MNode> GetConnectableNodes(string nodeId);
    }
}
