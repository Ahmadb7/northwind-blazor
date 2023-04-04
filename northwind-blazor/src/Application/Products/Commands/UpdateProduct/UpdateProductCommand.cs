using MediatR;

namespace northwind_blazor.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest
    {
        public int ProductId { get; set; }
        
        public string ProductCode { get; set; }

        public string ProductNameEn { get; set; }
        
        public string ProductNameFa { get; set; }

        public decimal? UnitPrice { get; set; }

        public int? SupplierId { get; set; }

        public int? CategoryId { get; set; }

        public bool Discontinued { get; set; }
    }
}
