using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar_DataAccess_Layer.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        int Insert(T entitie);
        int Update(T entitie);
        int Delete(int id);
    }
}
