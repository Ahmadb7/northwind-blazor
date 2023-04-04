using northwind_blazor.Application.Common.Mappings;

namespace northwind_blazor.Application.Orders.Queries.GetOrdersList
{
    public class OrderLookupDto : IMapFrom<Order>
    {
        public int OrderId { get; set; }
        public string Customer { get; set; }
        public string CustomerId { get; set; }
        public string Employee { get; set; }
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

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderLookupDto>()
                .ForMember(d => d.Customer, opt => opt.MapFrom(s => s.Customer != null ? s.Customer.CompanyName : string.Empty))
                .ForMember(d => d.Employee, opt => opt.MapFrom(s => s.Employee != null ? $"{s.Employee.LastName} {s.Employee.FirstName}" : string.Empty));
            //.ForMember(d => d.OrderId, opt => opt.MapFrom(s => s.OrderId))
            //.ForMember(d => d.CustomerId, opt => opt.MapFrom(s => s.CustomerId))
            //.ForMember(d => d.EmployeeId, opt => opt.MapFrom(s => s.EmployeeId));
        }
    }
}
