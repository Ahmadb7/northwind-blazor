using System.Collections.Generic;
using northwind_blazor.Application.Products.Queries.GetProductsFile;

namespace northwind_blazor.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildProductsFile(IEnumerable<ProductRecordDto> records);
    }
}
