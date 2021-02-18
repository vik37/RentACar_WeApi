using RentACar_DataAccess_Layer.Interfaces;
using RentACar_Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentACar_DataAccess_Layer.Repositories
{
    public class VehicleRepository : BaseRepository, IRepository<Vehicle>
    {
        public VehicleRepository(RentaCarDbContext context) : base(context) { }       

        public IEnumerable<Vehicle> GetAll()
        {
            return _db.Vehicle;
        }

        public Vehicle GetById(int id)
        {
            return _db.Vehicle.SingleOrDefault(x => x.Id == id);
        }

        public int Insert(Vehicle entitie)
        {
            _db.Vehicle.Add(entitie);
            return _db.SaveChanges();
        }

        public int Update(Vehicle entitie)
        {
            _db.Vehicle.Update(entitie);
            return _db.SaveChanges();
        }
        public int Delete(int id)
        {
            Vehicle vehicle = _db.Vehicle.SingleOrDefault(x => x.Id == id);
            if (vehicle == null)
                return -1;
            _db.Vehicle.Remove(vehicle);
            return _db.SaveChanges();
        }
    }
}
