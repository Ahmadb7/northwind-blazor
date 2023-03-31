using MediatR;

namespace northwind_blazor.Application.Categories.Queries.GetCategoriesList
{
    public class GetCategoriesListQuery : IRequest<CategoriesListVm>
    {
    }
}
