using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar_Businness_Layer.Interfaces;
using RentACar_DataTransfer_Layer.DTOModels;
using RentACar_DataTransfer_Layer.Enums;
using RentACar_Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.WebApi_RentACar.RentaMkDrive.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;

        public InvoiceController(IInvoiceService invoiceService, IOrderService orderService, IUserService userService)
        {
            _invoiceService = invoiceService;
            _orderService = orderService;
            _userService = userService;
        }

        [HttpGet("{orderId}")]
        public ActionResult<InvoiceDto> Get(int orderId)
        {
            try
            {
                var user = _userService.GetCurrentUser(User.Identity.Name);

                var model = _invoiceService.GetByOrderId(orderId, user.Id);
                return Ok(model);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            
        }

        [HttpPost]
        public ActionResult<Invoice> Post(string address, int paymentType, int orderId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = _userService.GetCurrentUser(User.Identity.Name);

                    InvoiceDto model = new InvoiceDto();
                    model.Address = address;
                    model.PaymentType = (PaymentTypeDto)paymentType;

                    var order = _orderService.GetOrderById(orderId);

                    if(order != null)
                    {
                        model.Order = order;
                        _invoiceService.Insert(model, user.Id, orderId);
                    }
                }
                return Ok("Invoice is successfully created!");
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
