using AutoMapper;
using MediatR;
using northwind_blazor.Application.Common.Exceptions;
using northwind_blazor.Application.Common.Interfaces;
using northwind_blazor.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace northwind_blazor.Application.Customers.Queries.GetCustomerDetail
{
    public class GetCustomerDetailQueryHandler : IRequestHandler<GetCustomerDetailQuery, CustomerDetailVm>
    {
        private readonly INorthwindDbContext _context;
        private readonly IMapper _mapper;

        public GetCustomerDetailQueryHandler(INorthwindDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CustomerDetailVm> Handle(GetCustomerDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Customers
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new Common.Exceptions.NotFoundException(nameof(Customer), request.Id);
            }

            return _mapper.Map<CustomerDetailVm>(entity);
        }
    }
}
