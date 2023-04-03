using AutoMapper;
using northwind_blazor.Application.Common.Mappings;
using northwind_blazor.Domain.Entities;

namespace northwind_blazor.Application.Orders.Queries.GetOrdersList
{
    public class OrderLookupDto : IMapFrom<Order>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Position { get; set; }

        public string Extension { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderLookupDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.OrderId))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.LastName + ", " + s.FirstName))
                .ForMember(d => d.Position, opt => opt.MapFrom(s => s.Title));
        }
    }
}
