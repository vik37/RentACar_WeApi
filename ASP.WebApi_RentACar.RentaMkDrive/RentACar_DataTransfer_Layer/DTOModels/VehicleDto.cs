using RentACar_DataTransfer_Layer.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar_DataTransfer_Layer.DTOModels
{
    public class VehicleDto
    {
        public int Id { get; set; }
        public VehicleTypeDto VehicleType { get; set; }        
        public string Brand { get; set; }        
        public string Model { get; set; }
        public int Doors { get; set; }        
        public string Color { get; set; }        
        public string Description { get; set; }        
        public double Price { get; set; }
        public int OrderId { get; set; }
    }
}
