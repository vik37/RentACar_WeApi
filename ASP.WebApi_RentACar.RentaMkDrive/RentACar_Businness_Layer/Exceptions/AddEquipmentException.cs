using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar_Businness_Layer.Exceptions
{
    public class AddEquipmentException : Exception
    {
        public int? EquipmentId { get; set; }
        public AddEquipmentException() : base("There has been an issue with the equipment")
        {

        }
        public AddEquipmentException(int? equipmentId, string message) : base(message)
        {
            EquipmentId = equipmentId;
        }
    }
}
