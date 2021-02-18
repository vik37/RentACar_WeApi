using AutoMapper;
using RentACar_Businness_Layer.Interfaces;
using RentACar_DataAccess_Layer.Interfaces;
using RentACar_DataTransfer_Layer.DTOModels;
using RentACar_Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar_Businness_Layer.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IRepository<Invoice> _invoiceRepo;
        private readonly IRepository<Order> _orderRepo;
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;
        public InvoiceService(IRepository<Invoice> invoiceRepo, IRepository<Order> orderRepo,
                              IUserRepository userRepo, IMapper mapper)
        {
            _invoiceRepo = invoiceRepo;
            _orderRepo = orderRepo;
            _userRepo = userRepo;
            _mapper = mapper;
        }
        public IEnumerable<InvoiceDto> GetAll(string userId)
        {
            throw new NotImplementedException();
        }

        public InvoiceDto GetById(int id, string userId)
        {
            return _mapper.Map<InvoiceDto>(_invoiceRepo.GetById(id));
        }

        public InvoiceDto GetByOrderId(int id, string userId)
        {
            Order order = _orderRepo.GetById(id);
            return _mapper.Map<InvoiceDto>(_invoiceRepo.GetById(order.Invoice.Id));
        }

        public int Insert(InvoiceDto model, string userId, int orderId)
        {
            Order order = _orderRepo.GetById(orderId);
            Invoice invoice = _mapper.Map<Invoice>(model);
            return _invoiceRepo.Insert(invoice);
        }
    }
}
