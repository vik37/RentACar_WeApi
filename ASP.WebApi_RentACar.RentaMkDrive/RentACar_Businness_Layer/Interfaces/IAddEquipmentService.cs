using RentACar_DataTransfer_Layer.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar_Businness_Layer.Interfaces
{
    public interface IAddEquipmentService
    {
        IEnumerable<AddEquipmentDto> GetAll();
        AddEquipmentDto GetById(int id);

        int Add(AddEquipmentDto model);
        int Remove(int id);
        int Update(AddEquipmentDto model);
    }
}
