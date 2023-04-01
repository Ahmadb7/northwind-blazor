using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using northwind_blazor.Application.Customers.Commands.CreateCustomer;
using northwind_blazor.Application.Customers.Commands.DeleteCustomer;
using northwind_blazor.Application.Customers.Commands.UpdateCustomer;
using northwind_blazor.Application.Customers.Queries.GetCustomerDetail;
using northwind_blazor.Application.Customers.Queries.GetCustomersList;
using northwind_blazor.WebUI.Server.Controllers;
using System.Threading.Tasks;

namespace northwind_blazor.WebUI.Controllers
{
    [Authorize]
    public class CustomersController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<CustomersListVm>> GetAll()
        {
            var vm = await Mediator.Send(new GetCustomersListQuery());

            return Ok(vm);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CustomerDetailVm>> Get(string id)
        {
            var vm = await Mediator.Send(new GetCustomerDetailQuery { Id = id });

            return Ok(vm);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody]CreateCustomerCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody]UpdateCustomerCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id)
        {
            await Mediator.Send(new DeleteCustomerCommand { Id = id });

            return NoContent();
        }
    }
}
