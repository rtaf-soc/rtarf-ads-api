using Its.Ads.Api.Models;
using Its.Ads.Api.ModelsViews;
using Its.Ads.Api.ViewsModels;

namespace Its.Ads.Api.Services
{
    public interface INodeService
    {
        public MVNode GetNodeById(string orgId, string nodeId);
        public MVNode? AddNode(string orgId, MNode node);
        public MVNode? DeleteNodeById(string orgId, string nodeId);
        public IEnumerable<MNode> GetNodes(string orgId, VMNode param);
        public IEnumerable<MNode> GetConnectableNodes(string orgId, string nodeId);
        public int GetNodeCount(string orgId, VMNode param);
        public MVNode? UpdateNodeById(string orgId, string nodeId, MNode node);

        public IEnumerable<MKeyValue> GetLayers(string orgId);
        public IEnumerable<MKeyValue> GetNodeTypes(string orgId);
        public IEnumerable<MNodeStatus> GetNodesStatus(string orgId, string layer);

        public MVNodeLink? AddLink(string orgId, string srcNodeId, MNodeLink link);
        public IEnumerable<MNodeLink> GetNodeLinks(string orgId, string nodeId);
        public MVNodeLink? DeleteLinkById(string orgId, string linkId);
        public MVNodeLink? UpdateLinkById(string orgId, string linkId, MNodeLink link);
    }
}
