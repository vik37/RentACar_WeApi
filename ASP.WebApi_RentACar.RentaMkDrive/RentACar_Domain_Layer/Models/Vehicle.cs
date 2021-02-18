using RentACar_Domain_Layer.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RentACar_Domain_Layer.Models
{
    public class Vehicle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public VehicleType VehicleType { get; set; }
        [Required]
        [MaxLength(50)]
        public string Brand { get; set; }
        [MaxLength(50)]
        public string Model { get; set; }
        public int Doors { get; set; }
        [Required]
        [MaxLength(50)]
        public string Color { get; set; }
        [Required]
        [MinLength(10)]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        public List<VehicleOrder> VehicleOrders { get; set; }
    }
}
