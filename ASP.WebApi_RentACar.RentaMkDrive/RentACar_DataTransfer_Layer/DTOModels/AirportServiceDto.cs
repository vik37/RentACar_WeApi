using RentACar_DataTransfer_Layer.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar_DataTransfer_Layer.DTOModels
{
    public class AirportServiceDto
    {
        public int Id { get; set; }
        public bool isClientWant { get; set; }
        public string City { get; set; }
        public AirportDto Airport { get; set; }
        public double Price { get; set; }
        public int OrderId { get; set; }
    }
}
