
using RentACar_Domain_Layer.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RentACar_Domain_Layer.Models
{
    public class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public PaymentType PaymentType { get; set; }
        [Required]
        public int IdCardNum { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string IdBankCard { get; set; }
        [Required]
        [MaxLength(50)]
        public string Phone { get; set; }
        [Required]
        [MaxLength(100)]
        public string City { get; set; }
        [Required]
        public int ZipCode { get; set; }
        [Required]
        public int DownPayment { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
