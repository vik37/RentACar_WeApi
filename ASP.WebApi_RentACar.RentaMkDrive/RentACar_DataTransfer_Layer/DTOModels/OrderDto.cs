using RentACar_DataTransfer_Layer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentACar_DataTransfer_Layer.DTOModels
{
    public class OrderDto
    {
        public int Id { get; set; }
        public bool isPayed { get; set; }
        public StatusTypeDto StatusType { get; set; }
        //public DateTime DateOfOrder { get; set; }
        public bool isDownPaid { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public UserDto User { get; set; }
        public List<AddEquipmentDto> Vehicles { get; set; }
        public List<AddEquipmentDto> AdditionalEquipments { get; set; }
        public List<AirportServiceDto> AirportServices { get; set; }
        public InvoiceDto Invoice { get; set; }
        public double VehiclePrice => Vehicles.Sum(v => v.Price);
        public double AddEquipmentPrice => AdditionalEquipments.Sum(a => a.Price);
        public double AirportServicePrice => AirportServices.Sum(a => a.Price);
        public double FullPrice { get => VehiclePrice + AddEquipmentPrice + AirportServicePrice;  } 

    }
}
