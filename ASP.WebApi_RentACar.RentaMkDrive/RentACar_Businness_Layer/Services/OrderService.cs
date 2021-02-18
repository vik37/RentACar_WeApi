using AutoMapper;
using RentACar_Businness_Layer.Interfaces;
using RentACar_DataAccess_Layer.Interfaces;
using RentACar_DataTransfer_Layer.DTOModels;
using RentACar_DataTransfer_Layer.Enums;
using RentACar_Domain_Layer.Enum;
using RentACar_Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentACar_Businness_Layer.Services
{
    public class OrderService : IOrderService
    {
        protected readonly IRepository<Order> _orderRepo;
        protected readonly IRepository<Vehicle> _vehicleRepo;
        protected readonly IRepository<AdditionalEquipment> _equipmentRepo;
        protected readonly IRepository<AirportService> _airportRepo;
        protected readonly IUserRepository _userRepo;
        protected readonly IMapper _mapper;
        public OrderService(IRepository<Order> orderRepo, IRepository<Vehicle> vehicleRepo,
            IRepository<AdditionalEquipment> equipmentRepo, IRepository<AirportService> airportRepo, IUserRepository userRepo, IMapper mapper)
        {
            _orderRepo = orderRepo;
            _vehicleRepo = vehicleRepo;
            _equipmentRepo = equipmentRepo;
            _airportRepo = airportRepo;
            _userRepo = userRepo;
            _mapper = mapper;
        }
        public IEnumerable<OrderDto> GetAllOrders()
        {
            IEnumerable<Order> orders = _orderRepo.GetAll();
            List<OrderDto> mappedOrders = _mapper.Map<List<OrderDto>>(orders);
            return mappedOrders;
        }
        public OrderDto GetOrderById(int id)
        {
            try
            {
                return _mapper.Map<OrderDto>(_orderRepo.GetById(id));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public OrderDto GetOrderById(int id, string userId)
        {
            try
            {
                User user = _userRepo.GetUserById(userId);
                Order order = _orderRepo.GetById(id);
                if(user.Id == order.UserId)
                {
                    return _mapper.Map<OrderDto>(order);
                }
                else
                {
                    return new OrderDto();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public int AddAdditionalEquipment(int orderId, int addEquipmentId, string userId)
        {
            AdditionalEquipment equipmnent = _equipmentRepo.GetById(addEquipmentId);
            User user = _userRepo.GetUserById(userId);
            Order order = _orderRepo.GetById(orderId);

            order.VehicleOrders.Add(new VehicleOrder()
            {
                AddEquipment = equipmnent,
                Order = order
            });
            order.User = user;
            return _orderRepo.Update(order);
        }

        public int AddAirportService(int orderId, int airportId, string userId)
        {
            AirportService airport = _airportRepo.GetById(airportId);
            Order order = _orderRepo.GetById(orderId);
            User user = _userRepo.GetUserById(userId);

            order.VehicleOrders.Add(new VehicleOrder()
            {
                AirportService = airport,
                Order = order
            });
            order.User = user;
            return _orderRepo.Update(order);
        }

        public int AddVehicle(int orderId, int vehicleId, string userId)
        {
            Vehicle vehicle = _vehicleRepo.GetById(vehicleId);
            Order order = _orderRepo.GetById(orderId);
            User user = _userRepo.GetUserById(userId);

            order.VehicleOrders.Add(new VehicleOrder()
            {
                Vehicle = vehicle,
                Order = order
            });
            order.User = user;
            return _orderRepo.Update(order);
        }

        public int ChangeStatus(int orderId, string userId, StatusTypeDto status)
        {
            try
            {
                Order order = _orderRepo.GetById(orderId);
                User user = _userRepo.GetUserById(userId);

                order.StatusType = (StatusType)status;
                if(status == StatusTypeDto.Pending)
                {
                    _orderRepo.Insert(new Order()
                    {
                        User = user,
                        DateOfOrder = DateTime.Now,
                        StatusType = StatusType.Init
                    });
                }
                return _orderRepo.Update(order);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public int CreateOrder(OrderDto order, string userId)
        {
            try
            {
                User user = _userRepo.GetUserById(userId);
                var mappedOrder = _mapper.Map<Order>(order);

                mappedOrder.User = user;
                return _orderRepo.Insert(mappedOrder);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

       

        public OrderDto GetCurrentOrder(string userId)
        {
            try
            {
                Order order = _orderRepo.GetAll()
                                        .Where(x => x.UserId == userId)
                                        .LastOrDefault();
                OrderDto mappedOrder = _mapper.Map<OrderDto>(order);
                return mappedOrder;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        

        public int RemoveOrder(int id)
        {
            throw new NotImplementedException();
        }
    }
}
