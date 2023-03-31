using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using northwind_blazor.Application.Common.Exceptions;
using northwind_blazor.Application.Common.Interfaces;
using northwind_blazor.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace northwind_blazor.Application.Products.Queries.GetProductDetail
{
    public class GetProductDetailQueryHandler : MediatR.IRequestHandler<GetProductDetailQuery, ProductDetailVm>
    {
        private readonly INorthwindDbContext _context;
        private readonly IMapper _mapper;

        public GetProductDetailQueryHandler(INorthwindDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductDetailVm> Handle(GetProductDetailQuery request, CancellationToken cancellationToken)
        {
            var vm = await _context.Products
                .ProjectTo<ProductDetailVm>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(p => p.ProductId == request.Id, cancellationToken);

            if (vm == null)
            {
                throw new Common.Exceptions.NotFoundException(nameof(Product), request.Id);
            }

            return vm;
        }
    }
}
