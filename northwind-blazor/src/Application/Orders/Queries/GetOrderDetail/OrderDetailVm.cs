﻿using AutoMapper;
using northwind_blazor.Application.Common.Mappings;
using northwind_blazor.Domain.Entities;
using System;
using System.Collections.Generic;

namespace northwind_blazor.Application.Orders.Queries.GetOrderDetail
{
    public class OrderDetailVm : IMapFrom<Order>
    {
        public int Id { get; set; }

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

        public virtual List<OrderTerritoryDto> Territories { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderDetailVm>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.OrderId))
                .ForMember(d => d.Title, opt => opt.MapFrom(s => s.TitleOfCourtesy))
                .ForMember(d => d.Position, opt => opt.MapFrom(s => s.Title))
                .ForMember(d => d.ManagerId, opt => opt.MapFrom(s => s.ReportsTo))
                .ForMember(d => d.Territories, opts => opts.MapFrom(s => s.OrderTerritories));
        }
    }
}