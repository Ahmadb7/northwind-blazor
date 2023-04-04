using northwind_blazor.Application.Common.Mappings;

namespace northwind_blazor.Application.Orders.Queries.GetOrderDetail
{
    public class OrderDetailVm : IMapFrom<OrderDetail>
    {
        public int OrderId { get; set; }
        public string Product { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrderDetail, OrderDetailVm>()
                .ForMember(d => d.Product, opt => opt.MapFrom(s => s.Product.ProductName));
        }
    }
}
