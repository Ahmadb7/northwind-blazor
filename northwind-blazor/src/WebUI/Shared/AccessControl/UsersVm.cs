namespace northwind_blazor.WebUI.Shared.AccessControl
{
    public class UsersVm
    {
        public IList<UserDto> Users { get; set; } = new List<UserDto>();
    }
}