using LojaFlamengoApi.BaseResponses;
using LojaFlamengoApi.Handlers.CreateItem;
using LojaFlamengoApi.Handlers.CreateOrder;
using LojaFlamengoApi.Handlers.ListOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LojaFlamengoApi.Controllers
{
    [Route("orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        public IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/{userId}/list")]
        public async Task<ActionResult<Unit>> ListOrders([AsParameters] long userId)
        {
            try
            {
                ListOrderRequest request = new ListOrderRequest() { UserId = userId };
                var result = await _mediator.Send(request);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("/create")]
        public async Task<ActionResult> CreateOrder(CreateOrderRequest request)
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
    }
}