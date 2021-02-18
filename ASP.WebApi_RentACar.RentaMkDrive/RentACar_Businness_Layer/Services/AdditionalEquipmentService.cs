using AutoMapper;
using RentACar_Businness_Layer.Exceptions;
using RentACar_Businness_Layer.Interfaces;
using RentACar_DataAccess_Layer.Interfaces;
using RentACar_DataTransfer_Layer.DTOModels;
using RentACar_Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentACar_Businness_Layer.Services
{
    public class AdditionalEquipmentService : IAddEquipmentService
    {
        protected readonly IRepository<AdditionalEquipment> _addEquipmentRepo;
        protected readonly IMapper _mapper;
        public AdditionalEquipmentService(IRepository<AdditionalEquipment> addEquipmentRepo, IMapper mapper)
        {
            _addEquipmentRepo = addEquipmentRepo;
            _mapper = mapper;
        }
       
        public IEnumerable<AddEquipmentDto> GetAll()
        {
            List<AdditionalEquipment> additionalEquipment = _addEquipmentRepo.GetAll().ToList();

            return _mapper.Map<List<AdditionalEquipment>, List<AddEquipmentDto>>(additionalEquipment);
        }

        public AddEquipmentDto GetById(int id)
        {
            var equipment = _addEquipmentRepo.GetById(id);
            if (equipment == null)
                throw new AddEquipmentException(id,"There is not that kind of stuff");
            return _mapper.Map<AddEquipmentDto>(equipment);
        }
        public int Add(AddEquipmentDto model)
        {
            if (string.IsNullOrEmpty(model.Name))
            {
                throw new AddEquipmentException(model.Id,"Can not be an empty string");
            }
            if (string.IsNullOrEmpty(model.Type))
            {
                throw new AddEquipmentException(model.Id,"Can not be an empty string");
            }
            if (string.IsNullOrEmpty(model.Description))
            {
                throw new AddEquipmentException(model.Id,"Can not be an empty string");
            }
            if (model.Price < 0)
            {
                throw new AddEquipmentException(model.Id,"Price can not be less then 0!");
            }
            if(model.Name.Count() < 3 || model.Name.Count() > 30)
            {
                throw new AddEquipmentException(model.Id,"Name can not be less then 3 and bigger then 30!");
            }
            if (model.Type.Count() < 3)
            {
                throw new AddEquipmentException(model.Id,"Name can not be less then 3!");
            }
            if (model.Description.Count() < 10)
            {
                throw new AddEquipmentException(model.Id,"Description can not be less then 10!");
            }
            var equipment = _mapper.Map<AdditionalEquipment>(model);
            return _addEquipmentRepo.Insert(equipment);
        }
        public int Remove(int id)
        {
            AdditionalEquipment equipment = _addEquipmentRepo.GetById(id);
            if (equipment == null)
                throw new AddEquipmentException(id,$"There is not thet stuff with id {id}!");
            return _addEquipmentRepo.Delete(equipment.Id);
        }

        public int Update(AddEquipmentDto model)
        {
            
            if(model == null)
            {
                throw new AddEquipmentException(model.Id, "No such equipment to be updated!");
            }
            
            var mappedEquipment = _mapper.Map<AdditionalEquipment>(model);
            return _addEquipmentRepo.Update(mappedEquipment);
        }
    }
}
