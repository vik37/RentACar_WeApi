using AutoMapper;
using RentACar_DataTransfer_Layer.DTOModels;
using RentACar_Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentACar_Businness_Layer.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Vehicle, VehicleDto>()
                .ForMember(dest => dest.OrderId, src => src.Ignore())
                .ReverseMap();
            CreateMap<AdditionalEquipment, AddEquipmentDto>()
                .ForMember(dest => dest.OrderId, src => src.Ignore())
                .ReverseMap();
            CreateMap<AirportService, AirportServiceDto>()
                .ForMember(dest => dest.OrderId, src => src.Ignore())
                .ReverseMap();
            CreateMap<Invoice, InvoiceDto>()
                .ReverseMap()
                .ForMember(dest => dest.IdCardNum, src => src.Ignore())
                .ForMember(dest => dest.IdBankCard, src => src.Ignore());

            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.AddEquipmentPrice, src => src.Ignore())
                .ForMember(dest => dest.AirportServicePrice, src => src.Ignore())
                .ForMember(dest => dest.VehiclePrice, src => src.Ignore())
                .ForMember(dest => dest.FullPrice, src => src.Ignore())
                .ForMember(dest => dest.Vehicles, src => src.MapFrom(x => x.VehicleOrders.Select(y =>
                                                                          new { y.AirportService, y.Vehicle, y.AddEquipment })))
                .ReverseMap()
                .ForMember(dest => dest.VehicleOrders, src => src.Ignore())
                .ForMember(dest => dest.DateOfOrder, src => src.Ignore())
                .ForMember(dest => dest.User, src => src.Ignore());
        }
    }
}
