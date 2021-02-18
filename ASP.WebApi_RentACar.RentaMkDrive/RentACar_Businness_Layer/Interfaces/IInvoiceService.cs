using RentACar_DataTransfer_Layer.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar_Businness_Layer.Interfaces
{
    public interface IInvoiceService
    {
        IEnumerable<InvoiceDto> GetAll(string userId);
        InvoiceDto GetById(int id, string userId);
        InvoiceDto GetByOrderId(int id, string userId);
        int Insert(InvoiceDto model, string userId, int orderId);
    }
}
