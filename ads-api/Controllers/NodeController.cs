using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Its.Ads.Api.Models;
using Its.Ads.Api.Services;
using Its.Ads.Api.ViewsModels;
using Its.Ads.Api.ModelsViews;

namespace Its.Ads.Api.Controllers
{
    [Authorize(Policy = "GenericRolePolicy")]
    [ApiController]
    [Route("/api/[controller]")]
    public class NodeController : ControllerBase
    {
        private readonly INodeService svc;

        [ExcludeFromCodeCoverage]
        public NodeController(INodeService service)
        {
            svc = service;
        }

        [ExcludeFromCodeCoverage]
        [HttpPost]
        [Route("org/{id}/action/AddNode")]
        public IActionResult AddNode(string id, [FromBody] MNode request)
        {
            var result = svc.AddNode(id, request);            
            return Ok(result);
        }

        [ExcludeFromCodeCoverage]
        [HttpDelete]
        [Route("org/{id}/action/DeleteNodeById/{nodeId}")]
        public IActionResult DeleteNodeById(string id, string nodeId)
        {
            var result = svc.DeleteNodeById(id, nodeId);
            return Ok(result);
        }

        [ExcludeFromCodeCoverage]
        [HttpGet]
        [Route("org/{id}/action/GetNodeById/{nodeId}")]
        public IActionResult GetNodeById(string id, string nodeId)
        {
            var result = svc.GetNodeById(id, nodeId);
            return Ok(result);
        }

        [HttpPost]
        [Route("org/{id}/action/GetNodes")]
        public IActionResult GetNodes(string id, [FromBody] VMNode param)
        {
            if (param.Limit <= 0)
            {
                param.Limit = 100;
            }

            var result = svc.GetNodes(id, param);
            return Ok(result);
        }

        [HttpGet]
        [Route("org/{id}/action/GetNodesByLayer/{layer}")]
        public IActionResult GetNodesByLayer(string id, string layer)
        {
            var param = new VMNode()
            {
                Limit = 100,
                Layer = layer 
            };

            var result = svc.GetNodes(id, param);
            return Ok(result);
        }

        [HttpPost]
        [Route("org/{id}/action/GetNodesStatus/{layer}")]
        public IActionResult GetNodesStatus(string id, string layer)
        {
            var result = svc.GetNodesStatus(id, layer);
            return Ok(result);
        }

        [HttpPost]
        [Route("org/{id}/action/GetNodeCount")]
        public IActionResult GetNodeCount(string id, [FromBody] VMNode param)
        {
            var result = svc.GetNodeCount(id, param);
            return Ok(result);
        }

        [ExcludeFromCodeCoverage]
        [HttpPost]
        [Route("org/{id}/action/UpdateNodeById/{nodeId}")]
        public IActionResult UpdateNodeById(string id, string nodeId, [FromBody] MNode request)
        {
            var result = svc.UpdateNodeById(id, nodeId, request);
            return Ok(result);
        }


        [ExcludeFromCodeCoverage]
        [HttpGet]
        [Route("org/{id}/action/GetLayers")]
        public IActionResult GetLayers(string id)
        {
            var result = svc.GetLayers(id);
            return Ok(result);
        }

        [ExcludeFromCodeCoverage]
        [HttpGet]
        [Route("org/{id}/action/GetNodeTypes")]
        public IActionResult GetNodeTypes(string id)
        {
            var result = svc.GetNodeTypes(id);
            return Ok(result);
        }


        [ExcludeFromCodeCoverage]
        [HttpGet]
        [Route("org/{id}/action/GetConnectableNodes/{nodeId}")]
        public IActionResult GetConnectableNodes(string id, string nodeId)
        {
            //TODO : Implement this
            var result = svc.GetConnectableNodes(id, nodeId);
            return Ok(result);
        }


        [ExcludeFromCodeCoverage]
        [HttpPost]
        [Route("org/{id}/action/AddLink/{srcNodeId}")]
        public IActionResult AddLink(string id, string srcNodeId, [FromBody] MNodeLink request)
        {
            var result = svc.AddLink(id, srcNodeId, request);
            return Ok(result);
        }

        [ExcludeFromCodeCoverage]
        [HttpGet]
        [Route("org/{id}/action/GetNodeLinks/{srcNodeId}")]
        public IActionResult GetNodeLinks(string id, string srcNodeId)
        {
            var result = svc.GetNodeLinks(id, srcNodeId);
            return Ok(result);
        }

        [ExcludeFromCodeCoverage]
        [HttpDelete]
        [Route("org/{id}/action/DeleteLinkById/{linkId}")]
        public IActionResult DeleteLinkById(string id, string linkId)
        {
            var result = svc.DeleteLinkById(id, linkId);
            return Ok(result);
        }

        [ExcludeFromCodeCoverage]
        [HttpPost]
        [Route("org/{id}/action/UpdateLinkById/{linkId}")]
        public IActionResult DeleteLinkById(string id, string linkId, [FromBody] MNodeLink request)
        {
            var result = svc.UpdateLinkById(id, linkId, request);
            return Ok(result);
        }
    }
}
