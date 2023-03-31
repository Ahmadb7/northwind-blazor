using CsvHelper.Configuration;
using northwind_blazor.Application.Products.Queries.GetProductsFile;

namespace northwind_blazor.Infrastructure.Files
{
    public sealed class ProductFileRecordMap : ClassMap<ProductRecordDto>
    {
        public ProductFileRecordMap()
        {
            AutoMap();
            Map(m => m.UnitPrice).Name("Unit Price").ConvertUsing(c => (c.UnitPrice ?? 0).ToString("C"));
        }
    }
}
