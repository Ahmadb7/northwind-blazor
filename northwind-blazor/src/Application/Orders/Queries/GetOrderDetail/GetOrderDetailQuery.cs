using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using northwind_blazor.Application.Common.Interfaces;
using northwind_blazor.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace northwind_blazor.Application.Orders.Queries.GetOrderDetail
{
    public class GetOrderDetailQuery : IRequest<OrderDetailVm>
    {
        public int Id { get; set; }

        public class GetOrderDetailQueryHandler : IRequestHandler<GetOrderDetailQuery, OrderDetailVm>
        {
            private readonly INorthwindDbContext _context;
            private readonly IMapper _mapper;

            public GeOrderDetailQueryHandler(INorthwindDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<OrderDetailVm> Handle(GetOrderDetailQuery request, CancellationToken cancellationToken)
            {
                var vm = await _context.Orders
                    .Where(e => e.OrderId == request.Id)
                    .ProjectTo<OrderDetailVm>(_mapper.ConfigurationProvider)
                    .SingleOrDefaultAsync(cancellationToken);

                return vm;
            }
        }
    }
}
