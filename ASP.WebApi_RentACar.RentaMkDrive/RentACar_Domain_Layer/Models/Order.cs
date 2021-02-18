using RentACar_Domain_Layer.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RentACar_Domain_Layer.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public bool isPayed { get; set; }
        public StatusType StatusType { get; set; }
        public DateTime DateOfOrder { get; set; }
        public bool isDownPaid { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public List<VehicleOrder> VehicleOrders { get; set; }
        public Invoice Invoice { get; set; }
    }
}
