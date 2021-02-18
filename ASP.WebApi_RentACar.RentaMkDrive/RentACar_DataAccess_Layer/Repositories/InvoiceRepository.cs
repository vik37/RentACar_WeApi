using RentACar_DataAccess_Layer.Interfaces;
using RentACar_Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentACar_DataAccess_Layer.Repositories
{
    public class InvoiceRepository : BaseRepository, IRepository<Invoice>
    {
        public InvoiceRepository(RentaCarDbContext context) : base(context) { }       

        public IEnumerable<Invoice> GetAll()
        {
            return _db.Invoice;
        }

        public Invoice GetById(int id)
        {
            return _db.Invoice.SingleOrDefault(x => x.Id == id);
        }

        public int Insert(Invoice entitie)
        {
            _db.Invoice.Add(entitie);
            return _db.SaveChanges();
        }

        public int Update(Invoice entitie)
        {
            _db.Invoice.Update(entitie);
            return _db.SaveChanges();
        }

        public int Delete(int id)
        {
            Invoice invoice = _db.Invoice.SingleOrDefault(x => x.Id == id);
            if (invoice == null)
                return -1;
            _db.Invoice.Remove(invoice);
            return _db.SaveChanges();
        }
    }
}
