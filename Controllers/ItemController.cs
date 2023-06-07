using LojaFlamengoApi.BaseResponses;
using LojaFlamengoApi.Handlers.CreateItem;
using LojaFlamengoApi.Handlers.DeleteItem;
using LojaFlamengoApi.Handlers.GetItem;
using LojaFlamengoApi.Handlers.ListItems;
using LojaFlamengoApi.Handlers.LoginUser;
using LojaFlamengoApi.Handlers.LogoutUser;
using LojaFlamengoApi.Handlers.RegisterUser;
using LojaFlamengoApi.Handlers.ResetUserPassword;
using LojaFlamengoApi.Handlers.UpdateItem;
using LojaFlamengoApi.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LojaFlamengoApi.Controllers
{
    [Route("item")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        public IMediator _mediator;

        public ItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<ActionResult<ItemResponse>> Register(CreateItemRequest request)
        {
            try
            {
                var result = await _mediator.Send(request);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("/{itemId}/get")]
        public async Task<ActionResult<ItemResponse>> Login([AsParameters] long itemId)
        {
            try
            {
                var request = new GetItemRequest() { ItemId = itemId };
                var result = await _mediator.Send(request);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("list")]
        public async Task<ActionResult<ItemResponse>> Login(ListItemsRequest request)
        {
            try
            {
                var result = await _mediator.Send(request);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("{itemId}/update")]
        public async Task<ActionResult<string>> Logout([AsParameters] long itemId, UpdateItemRequest request)
        {
            try
            {
                request.ItemId = itemId;
                await _mediator.Send(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{itemId}/remove")]
        public async Task<ActionResult<string>> ResetPassword([AsParameters] long itemId, DeleteItemRequest request)
        {
            try
            {
                request.ItemId = itemId;
                await _mediator.Send(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}