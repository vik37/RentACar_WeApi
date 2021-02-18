using RentACar_DataTransfer_Layer.DTOModels;
using RentACar_DataTransfer_Layer.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar_Businness_Layer.Interfaces
{
    public interface IVehicleService
    {
        IEnumerable<VehicleDto> GetAllVehicles();
        VehicleDto GetVehicleById(int id);
        IEnumerable<VehicleDto> GetVehiclesByType(VehicleTypeDto vehicleType);

        int AddVehicle(VehicleDto model);
        int RemoveVehicle(int id);
        int UpdateVehicle( VehicleDto model);
    }
}
