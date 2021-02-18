using RentACar_DataAccess_Layer.Interfaces;
using RentACar_Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentACar_DataAccess_Layer.Repositories
{
    public class AdditionalEquipmentRepository : BaseRepository, IRepository<AdditionalEquipment>
    {
        public AdditionalEquipmentRepository(RentaCarDbContext context) : base(context) { }       

        public IEnumerable<AdditionalEquipment> GetAll()
        {
            return _db.AddEquipment;
        }

        public AdditionalEquipment GetById(int id)
        {
            return _db.AddEquipment.SingleOrDefault(x => x.Id == id);
        }

        public int Insert(AdditionalEquipment entitie)
        {
            _db.AddEquipment.Add(entitie);
            return _db.SaveChanges();
        }

        public int Update(AdditionalEquipment entitie)
        {
            _db.AddEquipment.Update(entitie);
            return _db.SaveChanges();
        }
        public int Delete(int id)
        {
            AdditionalEquipment addEquipment = _db.AddEquipment.SingleOrDefault(x => x.Id == id);
            if (addEquipment == null)
                return -1;
            _db.AddEquipment.Remove(addEquipment);
            return _db.SaveChanges();
        }
    }
}
