using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar_Businness_Layer.Exceptions
{
    public class VehicleException : Exception
    {
        public int? VehicleId { get; set; }

        public VehicleException() : base("There has been an issue with the vehicle")
        {

        }
        public VehicleException(int? vehicleId, string message) : base(message)
        {
            VehicleId = vehicleId;
        }
    }
}
