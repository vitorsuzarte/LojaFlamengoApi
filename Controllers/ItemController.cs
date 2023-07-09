using LojaFlamengoApi.Handlers.CreateItem;
using LojaFlamengoApi.Handlers.GetItem;
using LojaFlamengoApi.Handlers.ListItems;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LojaFlamengoApi.Controllers
{
   [Route("api/item")]
   [ApiController]
   public class ItemController : ControllerBase
   {
      public IMediator _mediator;

      public ItemController(IMediator mediator)
      {
         _mediator = mediator;
      }

      [HttpPost("create")]
      public async Task<ActionResult<CreateItemResponse>> Create(CreateItemRequest request)
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

      [HttpGet("list")]
      public async Task<ActionResult<List<ListItemsResponse>>> Login(ListItemsRequest request)
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

      [HttpGet("get")]
      public async Task<ActionResult<GetItemResponse>> Logout(GetItemHandler request)
      {
         try
         {
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