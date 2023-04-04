using northwind_blazor.Application.Customers.Commands.UpdateCustomer;

namespace northwind_blazor.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {

            RuleFor(x => x.ProductCode).Length(20).NotEmpty();
            RuleFor(x => x.ProductNameEn).Length(40).Matches("^[a-zA-Z0-9]*$").NotEmpty();
            RuleFor(x => x.ProductNameFa).Length(60).Matches("^[\u0600-\u06FF\uFB8A\u067E\u0686\u06AF]+$").NotEmpty();
            
        }

    }
}
