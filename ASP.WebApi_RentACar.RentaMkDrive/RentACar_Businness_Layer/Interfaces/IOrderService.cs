using RentACar_DataTransfer_Layer.DTOModels;
using RentACar_DataTransfer_Layer.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar_Businness_Layer.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<OrderDto> GetAllOrders();
        OrderDto GetOrderById(int id);
        OrderDto GetOrderById(int id, string userId);
        int CreateOrder(OrderDto order, string userId);
        int AddVehicle(int orderId, int vehicleId, string userId);
        int AddAdditionalEquipment(int orderId, int addEquipmentId, string userId);
        int AddAirportService(int orderId, int airportId, string userId);
        OrderDto GetCurrentOrder(string userId);
        int ChangeStatus(int orderId, string userId, StatusTypeDto status);

        int RemoveOrder(int id);

    }
}
