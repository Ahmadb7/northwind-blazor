using MediatR;

namespace northwind_blazor.Application.Products.Queries.GetProductsList
{
    public class GetProductsListQuery : IRequest<ProductsListVm>
    {
    }
}
