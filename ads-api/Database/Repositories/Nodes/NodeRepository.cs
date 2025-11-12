using LinqKit;
using Its.Ads.Api.Models;
using Its.Ads.Api.ViewsModels;
using NetTopologySuite.Geometries;
using Confluent.Kafka;

namespace Its.Ads.Api.Database.Repositories
{
    public class NodeRepository : BaseRepository, INodeRepository
    {
        public NodeRepository(IDataContext ctx)
        {
            context = ctx;
        }

        public MNode AddNode(MNode node)
        {
            node.Id = Guid.NewGuid();
            node.CreatedDate = DateTime.UtcNow;
            node.OrgId = orgId;

            node.Location = new Point(node.Longitude, node.Latitude)
            {
                SRID = 4326
            };

            context!.Nodes!.Add(node);
            context.SaveChanges();

            return node;
        }

        private ExpressionStarter<MNode> NodePredicate(VMNode param)
        {
            var pd = PredicateBuilder.New<MNode>();

            pd = pd.And(p => p.OrgId!.Equals(orgId));

            if ((param.FullTextSearch != "") && (param.FullTextSearch != null))
            {
                var fullTextPd = PredicateBuilder.New<MNode>();
                fullTextPd = fullTextPd.Or(p => p.Name!.Contains(param.FullTextSearch));
                fullTextPd = fullTextPd.Or(p => p.Tags!.Contains(param.FullTextSearch));
                fullTextPd = fullTextPd.Or(p => p.Layer!.Contains(param.FullTextSearch));
                fullTextPd = fullTextPd.Or(p => p.Description!.Contains(param.FullTextSearch));

                pd = pd.And(fullTextPd);
            }

            if ((param.Layout != "") && (param.Layout != null))
            {
                var layoutPd = PredicateBuilder.New<MNode>();
                layoutPd = layoutPd.Or(p => p.Layer!.Equals(param.Layout));

                pd = pd.And(layoutPd);
            }

            if ((param.Type != "") && (param.Type != null))
            {
                var typePd = PredicateBuilder.New<MNode>();
                typePd = typePd.Or(p => p.Type!.Equals(param.Type));

                pd = pd.And(typePd);
            }

            return pd;
        }

        public int GetNodeCount(VMNode param)
        {
            var predicate = NodePredicate(param);
            var cnt = context!.Nodes!.Where(predicate).Count();

            return cnt;
        }

        public IEnumerable<MNode> GetNodes(VMNode param)
        {
            var limit = 0;
            var offset = 0;

            //Param will never be null
            if (param.Offset > 0)
            {
                //Convert to zero base
                offset = param.Offset - 1;
            }

            if (param.Limit > 0)
            {
                limit = param.Limit;
            }

            var predicate = NodePredicate(param!);
            var arr = context!.Nodes!.Where(predicate)
                .OrderBy(e => e.Layer)
                .ThenByDescending(e => e.CreatedDate)
                .Skip(offset)
                .Take(limit)
                .ToList();

            return arr;
        }

        public MNode GetNodeById(string nodeId)
        {
            Guid id = Guid.Parse(nodeId);

            var u = context!.Nodes!.Where(p => p!.Id!.Equals(id) && p!.OrgId!.Equals(orgId)).FirstOrDefault();
            return u!;
        }

        public MNode? DeleteNodeById(string nodeId)
        {
            Guid id = Guid.Parse(nodeId);

            var r = context!.Nodes!.Where(x => x.OrgId!.Equals(orgId) && x.Id.Equals(id)).FirstOrDefault();
            if (r != null)
            {
                context!.Nodes!.Remove(r);
                context.SaveChanges();
            }

            return r;
        }

        public MNode? DeleteNodeAndLinkById(string nodeId)
        {
            Guid id = Guid.Parse(nodeId);

            var r = context!.Nodes!.Where(x => x.OrgId!.Equals(orgId) && x.Id.Equals(id)).FirstOrDefault();
            if (r != null)
            {
                context!.Nodes!.Remove(r);
            }

            var nextLinks = context!.NodeLinks!.Where(x => x.OrgId!.Equals(orgId) && x.SourceNode.Equals(id)).ToList();
            context!.NodeLinks!.RemoveRange(nextLinks);

            var previousLinks = context!.NodeLinks!.Where(x => x.OrgId!.Equals(orgId) && x.DestinationNode.Equals(id)).ToList();
            context!.NodeLinks!.RemoveRange(previousLinks);

            context.SaveChanges();
            return r;

        }

        public MNode? UpdateNodeById(string nodeId, MNode node)
        {
            Guid id = Guid.Parse(nodeId);
            var result = context!.Nodes!.Where(x => x.OrgId!.Equals(orgId) && x.Id!.Equals(id)).FirstOrDefault();

            if (result != null)
            {
                result.Location = new Point(node.Longitude, node.Latitude)
                {
                    SRID = 4326
                };

                result.Tags = node.Tags;
                result.Name = node.Name;
                result.Description = node.Description;
                result.Latitude = node.Latitude;
                result.Longitude = node.Longitude;

                //ไม่อยากให้ Type ถูกแก้ได้
                //result.Type = node.Type;

                context!.SaveChanges();
            }

            return result!;
        }

        public MNodeLink AddLink(MNodeLink link)
        {
            var node = context!.Nodes!.Where(x => x.OrgId!.Equals(orgId) && x.Id.Equals(link.SourceNode)).FirstOrDefault();
            if (node == null)
            {
                return null!;
            }

            link.Layer = node.Layer;
            link.Id = Guid.NewGuid();
            link.CreatedDate = DateTime.UtcNow;
            link.OrgId = orgId;

            context!.NodeLinks!.Add(link);
            context.SaveChanges();

            return link;
        }

        public MNodeLink? UpdateLinkById(string linkId, MNodeLink link)
        {
            var node = context!.Nodes!.Where(x => x.OrgId!.Equals(orgId) && x.Id.Equals(link.SourceNode)).FirstOrDefault();
            if (node == null)
            {
                return null!;
            }

            Guid id = Guid.Parse(linkId);
            var result = context!.NodeLinks!.Where(x => x.OrgId!.Equals(orgId) && x.Id!.Equals(id)).FirstOrDefault();

            if (result != null)
            {
                result.Layer = node.Layer;
                result.Name = link.Name;
                result.Description = link.Description;
                result.Tags = link.Tags;

                context!.SaveChanges();
            }

            return result!;
        }

        public IEnumerable<MNodeStatus> GetNodesStatus(string layer)
        {
            var arr = context!.NodeStatus!
                .Where(l => l.OrgId == orgId && l.Layer == layer)
                .Join(context!.Nodes!,
                    l => l.NodeId,
                    n => n.Id,
                    (l, n) => new
                    {
                        NodeStatus = l,
                        Node = n
                    })
                .OrderBy(e => e.Node.Name)
                .Select(e => new MNodeStatus
                {
                    Id = e.NodeStatus.Id,
                    OrgId = e.NodeStatus.OrgId,
                    Status = e.NodeStatus.Status,
                    NodeId = e.NodeStatus.NodeId,
                    NodeName = e.Node.Name,
                    NodeDescription = e.Node.Description,
                    NodeType = e.Node.Type,
                    NodeTags = e.Node.Tags,
                })
                .ToList();

            return arr;
        }

        public IEnumerable<MNodeLink> GetNodeLinks(string nodeId)
        {
            var srcNodeId = Guid.Parse(nodeId);

            var arr = context!.NodeLinks!
                .Where(l => l.OrgId == orgId && l.SourceNode == srcNodeId)
                .Join(context!.Nodes!,
                    l => l.DestinationNode,
                    n => n.Id,
                    (l, n) => new
                    {
                        Link = l,
                        Node = n
                    })
                .OrderBy(e => e.Link.Name)
                .Select(e => new MNodeLink
                {
                    Id = e.Link.Id,
                    OrgId = e.Link.OrgId,
                    Description = e.Link.Description,
                    Name = e.Link.Name,
                    DestinationNode = e.Link.DestinationNode,
                    DestinationNodeType = e.Node.Type,
                    DestinationNodeName = e.Node.Name,
                    Tags = e.Link.Tags,
                })
                .ToList();

            return arr;
        }


        public IEnumerable<MNode> GetConnectableNodes(string nodeId)
        {
            //เอาเฉพาะที่อยู่ใน layer เดียวกันมาใช้
            var srcNodeId = Guid.Parse(nodeId);

            var r = context!.Nodes!.Where(x => x.OrgId!.Equals(orgId) && x.Id.Equals(srcNodeId)).FirstOrDefault();
            if (r == null)
            {
                return [];
            }

            var arr = context!.Nodes!.Where(x => x.OrgId!.Equals(orgId) && !x.Id.Equals(srcNodeId) && (x.Layer != null) && x.Layer.Equals(r.Layer))
                .OrderBy(e => e.Name)
                .ToList();

            return arr;
        }

        public MNodeLink? DeleteLinkById(string linkId)
        {
            Guid id = Guid.Parse(linkId);

            var r = context!.NodeLinks!.Where(x => x.OrgId!.Equals(orgId) && x.Id.Equals(id)).FirstOrDefault();
            if (r != null)
            {
                context!.NodeLinks!.Remove(r);
                context.SaveChanges();
            }

            return r;
        }
    }
}
