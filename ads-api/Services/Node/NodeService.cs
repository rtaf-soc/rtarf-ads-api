using Its.Ads.Api.Models;
using Its.Ads.Api.ModelsViews;
using Its.Ads.Api.Database.Repositories;
using Its.Ads.Api.Utils;
using Its.Ads.Api.ViewsModels;

namespace Its.Ads.Api.Services
{
    public class NodeService : BaseService, INodeService
    {
        private readonly INodeRepository? repository = null;

        public NodeService(INodeRepository repo) : base()
        {
            repository = repo;
        }

        public MVNode GetNodeById(string orgId, string nodeId)
        {
            var r = new MVNode()
            {
                Status = "OK",
                Description = "Success",
            };

            repository!.SetCustomOrgId(orgId);
            var result = repository!.GetNodeById(nodeId);

            r.Node = result;

            return r;
        }

        public MVNode? AddNode(string orgId, MNode node)
        {
            repository!.SetCustomOrgId(orgId);

            var r = new MVNode()
            {
                Status = "OK",
                Description = "Success",
            };

            if (!ServiceUtils.IsLatitudeValid(node.Latitude))
            {
                r.Status = "LATITUDE_INVALID_VALUE";
                r.Description = $"Latitude value is invalid!!!";

                return r;
            }

            if (!ServiceUtils.IsLongitudeValid(node.Longitude))
            {
                r.Status = "LONGITUDE_INVALID_VALUE";
                r.Description = $"Longitude value is invalid!!!";

                return r;
            }

            var result = repository!.AddNode(node);

            r.Node = result;

            return r;
        }

        public MVNode? DeleteNodeById(string orgId, string nodeId)
        {
            var r = new MVNode()
            {
                Status = "OK",
                Description = "Success"
            };

            if (!ServiceUtils.IsGuidValid(nodeId))
            {
                r.Status = "UUID_INVALID";
                r.Description = $"Node ID [{nodeId}] format is invalid";

                return r;
            }

            repository!.SetCustomOrgId(orgId);
            var m = repository!.DeleteNodeAndLinkById(nodeId);

            r.Node = m;
            if (m == null)
            {
                r.Status = "NOTFOUND";
                r.Description = $"Node ID [{nodeId}] not found for the organization [{orgId}]";
            }

            return r;
        }

        public IEnumerable<MNode> GetNodes(string orgId, VMNode param)
        {
            repository!.SetCustomOrgId(orgId);
            var result = repository!.GetNodes(param);

            return result;
        }

        public IEnumerable<MNodeStatus> GetNodesStatus(string orgId, string layer)
        {
            repository!.SetCustomOrgId(orgId);
            var result = repository!.GetNodesStatus(layer);

            return result; 
        }

        public IEnumerable<MNode> GetConnectableNodes(string orgId, string nodeId)
        {
            repository!.SetCustomOrgId(orgId);
            var result = repository!.GetConnectableNodes(nodeId);

            return result;
        }

        public int GetNodeCount(string orgId, VMNode param)
        {
            repository!.SetCustomOrgId(orgId);
            var result = repository!.GetNodeCount(param);

            return result;
        }

        public MVNode? UpdateNodeById(string orgId, string nodeId, MNode node)
        {
            var r = new MVNode()
            {
                Status = "OK",
                Description = "Success"
            };

            if (!ServiceUtils.IsLatitudeValid(node.Latitude))
            {
                r.Status = "LATITUDE_INVALID_VALUE";
                r.Description = $"Latitude value is invalid!!!";

                return r;
            }

            if (!ServiceUtils.IsLongitudeValid(node.Longitude))
            {
                r.Status = "LONGITUDE_INVALID_VALUE";
                r.Description = $"Longitude value is invalid!!!";

                return r;
            }

            repository!.SetCustomOrgId(orgId);
            var result = repository!.UpdateNodeById(nodeId, node);

            if (result == null)
            {
                r.Status = "NOTFOUND";
                r.Description = $"Node ID [{nodeId}] not found for the organization [{orgId}]";

                return r;
            }

            r.Node = result;
            return r;
        }

        public IEnumerable<MKeyValue> GetLayers(string orgId)
        {
            var list = new List<MKeyValue>()
            {
                new MKeyValue { Name = "RTARF INTERNAL NETWORK", Value = "RTARF INTERNAL NETWORK" },
                new MKeyValue { Name = "EXTERNAL NETWORK", Value = "EXTERNAL NETWORK" },
                new MKeyValue { Name = "THAILAND INFRASTRUCTURE", Value = "THAILAND INFRASTRUCTURE" },
                new MKeyValue { Name = "OPPOSITE INFRASTRUCTURE", Value = "OPPOSITE INFRASTRUCTURE" },
                new MKeyValue { Name = "OPPOSITE TARGET LIST", Value = "OPPOSITE TARGET LIST" },
            };

            return list;
        }

        public IEnumerable<MKeyValue> GetNodeTypes(string orgId)
        {
            var list = new List<MKeyValue>()
            {
                new MKeyValue { Name = "Router", Value = "Router" },
                new MKeyValue { Name = "Switch", Value = "Switch" },
                new MKeyValue { Name = "Server", Value = "Server" },
                new MKeyValue { Name = "Firewall", Value = "Firewall" },
            };

            return list;
        }

        public IEnumerable<MNodeLink> GetNodeLinks(string orgId, string nodeId)
        {
            repository!.SetCustomOrgId(orgId);
            var arr = repository!.GetNodeLinks(nodeId);

            return arr;
        }

        public MVNodeLink? UpdateLinkById(string orgId, string linkId, MNodeLink link)
        {
            var r = new MVNodeLink()
            {
                Status = "OK",
                Description = "Success"
            };

            if (!ServiceUtils.IsGuidValid(linkId))
            {
                r.Status = "UUID_INVALID";
                r.Description = $"Link ID [{linkId}] format is invalid";

                return r;
            }

            repository!.SetCustomOrgId(orgId);
            var result = repository!.UpdateLinkById(linkId, link);

            if (result == null)
            {
                r.Status = "NOTFOUND";
                r.Description = $"Link ID [{linkId}] not found for the organization [{orgId}]";

                return r;
            }

            r.NodeLink = result;
            return r;
        }

        public MVNodeLink? DeleteLinkById(string orgId, string linkId)
        {
            var r = new MVNodeLink()
            {
                Status = "OK",
                Description = "Success"
            };

            if (!ServiceUtils.IsGuidValid(linkId))
            {
                r.Status = "UUID_INVALID";
                r.Description = $"Link ID [{linkId}] format is invalid";

                return r;
            }

            repository!.SetCustomOrgId(orgId);
            var m = repository!.DeleteLinkById(linkId);

            r.NodeLink = m;
            if (m == null)
            {
                r.Status = "NOTFOUND";
                r.Description = $"Link ID [{linkId}] not found for the organization [{orgId}]";
            }

            return r;
        }

        public MVNodeLink? AddLink(string orgId, string srcNodeId, MNodeLink link)
        {
            repository!.SetCustomOrgId(orgId);
            var r = new MVNodeLink()
            {
                Status = "OK",
                Description = "Success",
            };

            if (!ServiceUtils.IsGuidValid(srcNodeId))
            {
                r.Status = "UUID_INVALID";
                r.Description = $"Node ID [{srcNodeId}] format is invalid";

                return r;
            }

            if (link.DestinationNode == null)
            {
                r.Status = "DESTINATION_NODE_MISSING";
                r.Description = $"Destination node missing!!!";

                return r;
            }

            var dstIdStr = link.DestinationNode.ToString()!;
            if (!ServiceUtils.IsGuidValid(dstIdStr))
            {
                r.Status = "UUID_INVALID";
                r.Description = $"Destination node ID [{dstIdStr}] format is invalid";

                return r;
            }

            link.SourceNode = Guid.Parse(srcNodeId);;
            var result = repository!.AddLink(link);

            r.NodeLink = result;
            return r;
        }
    }
}
