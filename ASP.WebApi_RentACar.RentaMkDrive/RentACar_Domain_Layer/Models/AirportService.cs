using RentACar_Domain_Layer.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RentACar_Domain_Layer.Models
{
    public class AirportService
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public bool isClientWant { get; set; }
        [MaxLength(200)]
        public string City { get; set; }
        public Airport Airport { get; set; }
        public double Price { get; set; }

        public List<VehicleOrder> VehicleOrders { get; set; }
    }
}
