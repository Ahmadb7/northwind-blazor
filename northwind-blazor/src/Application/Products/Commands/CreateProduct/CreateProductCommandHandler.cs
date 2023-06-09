﻿using System.Threading;
using System.Threading.Tasks;
using MediatR;
using northwind_blazor.Application.Common.Interfaces;
using northwind_blazor.Domain.Entities;

namespace northwind_blazor.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly INorthwindDbContext _context;

        public CreateProductCommandHandler(INorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = new Product
            {
                ProductCode = request.ProductCode,
                ProductNameEn = request.ProductNameEn,
                ProductNameFa = request.ProductNameFa,
                CategoryId = request.CategoryId,
                SupplierId = request.SupplierId,
                UnitPrice = request.UnitPrice,
                Discontinued = request.Discontinued
            };

            _context.Products.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.ProductId;
        }
    }
}
