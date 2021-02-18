using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RentACar_Domain_Layer.Models
{
    public class VehicleOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set;  }
        public int AddEquipmenrId { get; set; }
        public AdditionalEquipment AddEquipment { get; set; }
        public int AirportServiceId { get; set; }
        public AirportService AirportService { get; set; }
    }   
}
