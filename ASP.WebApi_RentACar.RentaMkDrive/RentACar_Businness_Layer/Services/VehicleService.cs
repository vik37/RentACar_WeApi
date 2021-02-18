using AutoMapper;
using RentACar_Businness_Layer.Exceptions;
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
    public class VehicleService : IVehicleService
    {
        protected readonly IRepository<Vehicle> _vehicleRepo;
        protected readonly IMapper _mapper;
        public VehicleService(IRepository<Vehicle> vehicleRepo, IMapper mapper)
        {
            _vehicleRepo = vehicleRepo;
            _mapper = mapper;
        }       

        public IEnumerable<VehicleDto> GetAllVehicles()
        {
            List<Vehicle> vehicles = _vehicleRepo.GetAll().ToList();
            return _mapper.Map<List<Vehicle>, List<VehicleDto>>(vehicles);
        }

        public VehicleDto GetVehicleById(int id)
        {
            Vehicle vehicle = _vehicleRepo.GetById(id);

            VehicleDto vehicleDto = _mapper.Map<VehicleDto>(vehicle);
            if(vehicleDto != null)
            {
                return vehicleDto;
            }
            else
            {
                throw new Exception($"Vehicle with id {id} does not exist!");
            }
            
        }

        public IEnumerable<VehicleDto> GetVehiclesByType(VehicleTypeDto vehicleType)
        {
            List<Vehicle> vehicles = _vehicleRepo.GetAll().ToList();
            List<VehicleDto> vehicleDto = _mapper.Map<List<Vehicle>, List<VehicleDto>>(vehicles);
            var vehicleByType = vehicleDto.Where(x => x.VehicleType == vehicleType).ToList();
            return vehicleByType;
        }

        public int AddVehicle(VehicleDto model)
        {
            if (string.IsNullOrEmpty(model.Brand))
            {
                throw new VehicleException(null, "Can not empty string");
            }
            if (string.IsNullOrEmpty(model.Color))
            {
                throw new VehicleException(null, "Can not empty string");
            }
            if (string.IsNullOrEmpty(model.Description))
            {
                throw new VehicleException(null, "Can not empty string");
            }
            if (model.Brand.Count() < 3 || model.Brand.Count() > 30)
            {
                throw new VehicleException(null, "Can not empty string");
            }
            if (model.Color.Count() < 3 || model.Brand.Count() > 50)
            {
                throw new VehicleException(null, "Can not empty string");
            }
            if (model.Description.Count() < 10)
            {
                throw new VehicleException(null, "Can not empty string");
            }
            if((int)model.VehicleType < 0 || (int)model.VehicleType > 5)
            {
                throw new VehicleException(null, "There is not cind of type!");
            }
            if(model.Price < 0)
            {
                throw new VehicleException(null, "Price can not be less then 0!");
            }
            var vehicle = _mapper.Map<Vehicle>(model);
            return _vehicleRepo.Insert(vehicle);
        }

        public int RemoveVehicle(int id)
        {
            Vehicle vehicle = _vehicleRepo.GetById(id);
            if (vehicle == null)
                throw new VehicleException(null, $"There is not have that vehicle with id {id}!");
            return _vehicleRepo.Delete(vehicle.Id);
        }

        public int UpdateVehicle(VehicleDto model)
        {

            if (model == null)
            {
                throw new VehicleException(model.Id, "No such vehicle to be updated!");
            }
           
            var mappedVehicle = _mapper.Map<Vehicle>(model);
            return _vehicleRepo.Update(mappedVehicle);
            
        }
    }
}
