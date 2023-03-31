using MediatR;

namespace northwind_blazor.Application.Products.Queries.GetProductDetail
{
    public class GetProductDetailQuery : IRequest<ProductDetailVm>
    {
        public int Id { get; set; }
    }
}
