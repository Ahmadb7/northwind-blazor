using northwind_blazor.Application.Common.Mappings;

namespace northwind_blazor.Application.Orders.Queries.GetOrderDetail
{
    public class OrderDetailDto : IMapFrom<OrderDetail>
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrderDetail, OrderDetailDto>()
                .ForMember(d => d.OrderId, opts => opts.MapFrom(s => s.OrderId))
                .ForMember(d => d.ProductId, opts => opts.MapFrom(s => s.ProductId))
                .ForMember(d => d.UnitPrice, opts => opts.MapFrom(s => s.UnitPrice))
                .ForMember(d => d.Quantity, opts => opts.MapFrom(s => s.Quantity))
                .ForMember(d => d.Discount, opts => opts.MapFrom(s => s.Discount));
        }
    }
}
