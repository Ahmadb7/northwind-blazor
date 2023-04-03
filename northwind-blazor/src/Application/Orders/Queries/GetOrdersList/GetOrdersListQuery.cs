using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using northwind_blazor.Application.Common.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace northwind_blazor.Application.Orders.Queries.GetOrdersList
{
    public class GetOrdersListQuery : IRequest<OrdersListVm>
    {
        public class GetOrdersListQueryHandler : IRequestHandler<GetOrdersListQuery, OrdersListVm>
        {
            private readonly INorthwindDbContext _context;
            private readonly IMapper _mapper;

            public GetOrdersListQueryHandler(INorthwindDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<OrdersListVm> Handle(GetOrdersListQuery request, CancellationToken cancellationToken)
            {
                var Orders = await _context.Orders
                    .ProjectTo<OrderLookupDto>(_mapper.ConfigurationProvider)
                    .OrderBy(e => e.Name)
                    .ToListAsync(cancellationToken);

                var vm = new OrdersListVm
                {
                    Orders = Orders
                };
                 
                return vm;
            }
        }
    }
}
