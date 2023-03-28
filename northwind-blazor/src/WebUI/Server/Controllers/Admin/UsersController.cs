using Microsoft.AspNetCore.Mvc;
using northwind_blazor.Application.Users.Commands;
using northwind_blazor.Application.Users.Queries;
using northwind_blazor.WebUI.Shared.AccessControl;
using northwind_blazor.WebUI.Shared.Authorization;

namespace northwind_blazor.WebUI.Server.Controllers.Admin
{
    [Route("api/Admin/[controller]")]
    public class UsersController : ApiControllerBase
    {
        // GET: api/Admin/Users
        [HttpGet]
        [Authorize(Permissions.ViewUsers | Permissions.ManageUsers)]
        public async Task<ActionResult<UsersVm>> GetUsers()
        {
            return await Mediator.Send(new GetUsersQuery());
        }

        // GET: api/Admin/Users/5
        [HttpGet("{id}")]
        [Authorize(Permissions.ViewUsers)]
        public async Task<ActionResult<UserDetailsVm>> GetUser(string id)
        {
            return await Mediator.Send(new GetUserQuery(id));
        }

        // PUT: api/Admin/Users/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Permissions.ManageUsers)]
        public async Task<IActionResult> PutUser(string id, UserDto updatedUser)
        {
            if (id != updatedUser.Id) return BadRequest();

            await Mediator.Send(new UpdateUserCommand(updatedUser));

            return NoContent();
        }
    }
}