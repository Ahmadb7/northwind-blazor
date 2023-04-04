using MediatR;
using northwind_blazor.Application.Common.Interfaces;
using northwind_blazor.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace northwind_blazor.Application.Orders.Commands.UpsertOrder
{
    public class UpsertOrderCommand : IRequest<int>
    {
        public int OrderId { get; set; }
        public string CustomerId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int? ShipVia { get; set; }
        public decimal? Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }

        public class UpsertOrderCommandHandler : IRequestHandler<UpsertOrderCommand, int>
        {
            private readonly INorthwindDbContext _context;

            public UpsertOrderCommandHandler(INorthwindDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpsertOrderCommand request, CancellationToken cancellationToken)
            {
                Order entity;

                if (request != null)
                {
                    entity = await _context.Orders.FindAsync(request.OrderId);
                }
                else
                {
                    entity = new Order();

                    _context.Orders.Add(entity);
                }

                entity.CustomerId = request.CustomerId;
                entity.EmployeeId = request.EmployeeId;
                entity.Freight = request.Freight;
                entity.OrderDate = request.OrderDate;
                entity.RequiredDate = request.RequiredDate;
                entity.ShipAddress = request.ShipAddress;
                entity.ShipCity = request.ShipCity;
                entity.ShipCountry = request.ShipCountry;
                entity.ShipName = request.ShipName;
                entity.ShippedDate = request.ShippedDate;
                entity.ShipPostalCode = request.ShipPostalCode;
                entity.ShipRegion = request.ShipRegion;
                entity.ShipVia = request.ShipVia;

                await _context.SaveChangesAsync(cancellationToken);

                return entity.OrderId;
            }
        }
    }
}
