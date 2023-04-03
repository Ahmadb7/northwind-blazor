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
        public int? Id { get; set; }

        public string Title { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Region { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public string HomePhone { get; set; }

        public string Position { get; set; }

        public string Extension { get; set; }

        public DateTime? HireDate { get; set; }

        public string Notes { get; set; }

        public byte[] Photo { get; set; }

        public int? ManagerId { get; set; }

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

                if (request.Id.HasValue)
                {
                    entity = await _context.Orders.FindAsync(request.Id.Value);
                }
                else
                {
                    entity = new Order();

                    _context.Orders.Add(entity);
                }

                entity.TitleOfCourtesy = request.Title;
                entity.FirstName = request.FirstName;
                entity.LastName = request.LastName;
                entity.BirthDate = request.BirthDate;
                entity.Address = request.Address;
                entity.City = request.City;
                entity.Region = request.Region;
                entity.PostalCode = request.PostalCode;
                entity.Country = request.Country;
                entity.HomePhone = request.HomePhone;
                entity.Title = request.Position;
                entity.Extension = request.Extension;
                entity.HireDate = request.HireDate;
                entity.Notes = request.Notes;
                entity.Photo = request.Photo;
                entity.ReportsTo = request.ManagerId;

                await _context.SaveChangesAsync(cancellationToken);

                return entity.OrderId;
            }
        }
    }
}
