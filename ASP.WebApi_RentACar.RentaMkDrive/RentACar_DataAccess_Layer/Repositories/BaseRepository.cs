using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar_DataAccess_Layer.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly RentaCarDbContext _db;
        public BaseRepository(RentaCarDbContext db)
        {
            _db = db;
        }
    }
}
