using System.Collections.Generic;

namespace northwind_blazor.Application.Products.Queries.GetProductsList
{
    public class ProductsListVm
    {
        public List<ProductDto> Products { get; set; }

        public bool CreateEnabled { get; set; }
    }
}
