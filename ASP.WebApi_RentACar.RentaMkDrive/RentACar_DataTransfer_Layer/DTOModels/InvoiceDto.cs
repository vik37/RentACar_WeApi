using RentACar_DataTransfer_Layer.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar_DataTransfer_Layer.DTOModels
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public string Address { get; set; }
        
        public PaymentTypeDto PaymentType { get; set; }
        
        //public int IdCardNum { get; set; }
        
        //public string IdBankCard { get; set; }
        
        public string Phone { get; set; }
        
        public string City { get; set; }
        
        public int ZipCode { get; set; }
        
        public int DownPayment { get; set; }
        public int OrderId { get; set; }
        public OrderDto Order { get; set; }
    }
}
