using RentACar_DataAccess_Layer.Interfaces;
using RentACar_Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentACar_DataAccess_Layer.Repositories
{
    public class AirportServiceRepository : BaseRepository, IRepository<AirportService>
    {
        public AirportServiceRepository(RentaCarDbContext context) : base(context) { }        

        public IEnumerable<AirportService> GetAll()
        {
            return _db.AirportService;
        }

        public AirportService GetById(int id)
        {
            return _db.AirportService.SingleOrDefault(x => x.Id == id);
        }

        public int Insert(AirportService entitie)
        {
            _db.AirportService.Add(entitie);
            return _db.SaveChanges();
        }

        public int Update(AirportService entitie)
        {
            _db.AirportService.Update(entitie);
            return _db.SaveChanges();
        }
        public int Delete(int id)
        {
            AirportService airService = _db.AirportService.SingleOrDefault(x => x.Id == id);
            if (airService == null)
                return -1;
            _db.AirportService.Remove(airService);
            return _db.SaveChanges();
        }
    }
}
