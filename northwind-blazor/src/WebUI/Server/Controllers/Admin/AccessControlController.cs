using Microsoft.AspNetCore.Mvc;
using northwind_blazor.Application.AccessControl.Commands;
using northwind_blazor.Application.AccessControl.Queries;
using northwind_blazor.WebUI.Shared.AccessControl;
using northwind_blazor.WebUI.Shared.Authorization;

namespace northwind_blazor.WebUI.Server.Controllers.Admin
{
    [Route("api/Admin/[controller]")]
    public class AccessControlController : ApiControllerBase
    {
        [HttpGet]
        [Authorize(Permissions.ViewAccessControl)]
        public async Task<ActionResult<AccessControlVm>> GetConfiguration()
        {
            return await Mediator.Send(new GetAccessControlQuery());
        }

        [HttpPut]
        [Authorize(Permissions.ConfigureAccessControl)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateConfiguration(RoleDto updatedRole)
        {
            await Mediator.Send(new UpdateAccessControlCommand(updatedRole.Id, updatedRole.Permissions));

            return NoContent();
        }
    }
}