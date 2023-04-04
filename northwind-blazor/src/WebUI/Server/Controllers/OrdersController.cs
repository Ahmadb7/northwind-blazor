using Microsoft.AspNetCore.Mvc;
using northwind_blazor.Application.Orders.Commands.DeleteOrder;
using northwind_blazor.Application.Orders.Commands.UpsertOrder;
using northwind_blazor.Application.Orders.Queries.GetOrderDetail;
using northwind_blazor.Application.Orders.Queries.GetOrdersList;
using northwind_blazor.WebUI.Server.Controllers;

namespace northwind_blazor.WebUI.Controllers
{
    public class OrdersController : ApiControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IList<OrderLookupDto>>> GetAll()
        {
            return Ok(await Mediator.Send(new GetOrdersListQuery()));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<OrderDetailVm>>> Get(int id)
        {
            return Ok(await Mediator.Send(new GetOrderDetailQuery { Id = id }));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Upsert(UpsertOrderCommand command)
        {
            var id = await Mediator.Send(command);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteOrderCommand { Id = id });

            return NoContent();
        }
    }
}
