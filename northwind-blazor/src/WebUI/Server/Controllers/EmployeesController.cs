using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using northwind_blazor.Application.Employees.Commands.DeleteEmployee;
using northwind_blazor.Application.Employees.Commands.UpsertEmployee;
using northwind_blazor.Application.Employees.Queries.GetEmployeeDetail;
using northwind_blazor.Application.Employees.Queries.GetEmployeesList;
using northwind_blazor.WebUI.Server.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace northwind_blazor.WebUI.Controllers
{
    public class EmployeesController : ApiControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IList<EmployeeLookupDto>>> GetAll()
        {
            return Ok(await Mediator.Send(new GetEmployeesListQuery()));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<EmployeeDetailVm>> Get(int id)
        {
            return Ok(await Mediator.Send(new GetEmployeeDetailQuery { Id = id }));
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Upsert(UpsertEmployeeCommand command)
        {
            var id = await Mediator.Send(command);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteEmployeeCommand { Id = id });

            return NoContent();
        }
    }
}
