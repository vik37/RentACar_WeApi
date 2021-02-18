using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar_Businness_Layer.Interfaces;
using RentACar_DataTransfer_Layer.DTOModels;
using RentACar_DataTransfer_Layer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.WebApi_RentACar.RentaMkDrive.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;
        private readonly IVehicleService _vehicleService;
        public OrderController(IOrderService orderService, IUserService userService, IVehicleService vehicleService)
        {
            _orderService = orderService;
            _userService = userService;
            _vehicleService = vehicleService;
        }
        [HttpGet]
        public ActionResult<List<OrderDto>> Get()
        {
            try
            {
                return Ok(_orderService.GetAllOrders());
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("orders")]
        public ActionResult<List<OrderDto>> GetAllUsersOrders()
        {
            try
            {
                UserDto user = _userService.GetCurrentUser(User.Identity.Name);
                List<OrderDto> orders = _orderService.GetAllOrders()
                                                     .Where(x => x.User.Id == user.Id)
                                                     .ToList();
                return Ok(orders);

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<OrderDto> Get(int orderId)
        {
            try
            {
                var user = _userService.GetCurrentUser(User.Identity.Name);
                var order = _orderService.GetOrderById(orderId, user.Id);
                if(order.Id > 0)
                {
                    return Ok(order);
                }
                else
                {
                    return BadRequest($"There is not that id {orderId}");
                }
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("current")]
        public ActionResult<OrderDto> GetCurrentOrder()
        {
            try
            {
                var user = _userService.GetCurrentUser(User.Identity.Name);
                var order = _orderService.GetCurrentOrder(user.Id);
                return Ok(order);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut("Approve/{orderId}")]
        public ActionResult Approve(int orderId)
        {
            try
            {
                var order = _orderService.GetOrderById(orderId);
                _orderService.ChangeStatus(order.Id, order.User.Id, StatusTypeDto.Confirmed);
                return Ok("Approve successfully!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut("Decline/{orderId}")]
        public ActionResult Deline(int orderId)
        {
            try
            {
                var order = _orderService.GetOrderById(orderId);
                _orderService.ChangeStatus(order.Id, order.User.Id, StatusTypeDto.Declined);
                return Ok("Approve successfully!");
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("Status/{statusId}")]
        public ActionResult ChangeStatus(int orderId, int statusId)
        {
            try
            {
                var user = _userService.GetCurrentUser(User.Identity.Name);
                _orderService.ChangeStatus(orderId, user.Id, (StatusTypeDto)statusId);
                return Ok("Status has change successfully!");
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult PostVehicle(int vehicleId)
        {
            try
            {
                var user = _userService.GetCurrentUser(User.Identity.Name);
                var order = _orderService.GetCurrentOrder(user.Id);

                int result = _orderService.AddVehicle(order.Id, vehicleId, user.Id);

                if(result >= 0)
                {
                    return Ok($"Product was added successfully. Result {result}");
                }
                else
                {
                    return BadRequest($"Product was not added successfully. Result: {result}");
                }
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
