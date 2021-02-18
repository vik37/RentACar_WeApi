using Microsoft.EntityFrameworkCore;
using RentACar_DataAccess_Layer.Interfaces;
using RentACar_Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentACar_DataAccess_Layer.Repositories
{
    public class OrderRepository : BaseRepository, IRepository<Order>
    {
        public OrderRepository(RentaCarDbContext context) : base(context) { }

        public IEnumerable<Order> GetAll()
        {
            return _db.Order
                .Include(x => x.VehicleOrders)
                   .ThenInclude(x => x.Vehicle)
                .Include(y => y.VehicleOrders)
                   .ThenInclude(y => y.AddEquipment)
                .Include(c => c.VehicleOrders)
                   .ThenInclude(c => c.AirportService)
                .Include(x => x.User)
                .Include(x => x.Invoice);
                
        }

        public Order GetById(int id)
        {
            return _db.Order
                .Include(x => x.VehicleOrders)
                   .ThenInclude(x => x.Vehicle)
                .Include(y => y.VehicleOrders)
                   .ThenInclude(y => y.AddEquipment)
                .Include(c => c.VehicleOrders)
                   .ThenInclude(c => c.AirportService)
                .Include(x => x.User)
                .Include(x => x.Invoice)
                .SingleOrDefault(x => x.Id == id);
        }

        public int Insert(Order entitie)
        {
            _db.Order.Add(entitie);
            return _db.SaveChanges();
        }

        public int Update(Order entitie)
        {
            _db.Update(entitie);
            return _db.SaveChanges();
        }

        public int Delete(int id)
        {
            Order order = _db.Order.SingleOrDefault(x => x.Id == id);
            if (order == null)
                return -1;
            _db.Order.Remove(order);
            return _db.SaveChanges();
        }        
    }
}
