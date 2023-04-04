namespace northwind_blazor.Application.Orders.Queries.GetOrderDetail
{
    public class GetOrderDetailQuery : IRequest<List<OrderDetailVm>>
    {
        public int Id { get; set; }

        public class GetOrderDetailQueryHandler : IRequestHandler<GetOrderDetailQuery, List<OrderDetailVm>>
        {
            private readonly INorthwindDbContext _context;
            private readonly IMapper _mapper;

            public GetOrderDetailQueryHandler(INorthwindDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<OrderDetailVm>> Handle(GetOrderDetailQuery request, CancellationToken cancellationToken)
            {
                var vm = await _context.OrderDetails
                    .Where(e => e.OrderId == request.Id)
                    .ProjectTo<OrderDetailVm>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                return vm;
            }
        }
    }
}
