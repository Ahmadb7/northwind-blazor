using northwind_blazor.Application.Customers.Commands.CreateCustomer;
using System.Text.RegularExpressions;

namespace northwind_blazor.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.ProductCode).Length(20).NotEmpty();
            RuleFor(x => x.ProductNameEn).Length(40).Matches("^[a-zA-Z0-9]*$").NotEmpty();
            RuleFor(x => x.ProductNameFa).Length(60).Matches("^[\u0600-\u06FF\uFB8A\u067E\u0686\u06AF]+$").NotEmpty();
        }
    }
}
