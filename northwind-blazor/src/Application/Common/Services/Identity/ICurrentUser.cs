namespace northwind_blazor.Application.Common.Services.Identity
{
    public interface ICurrentUser
    {
        string? UserId { get; }
    }
}