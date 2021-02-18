using RentACar_Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar_DataAccess_Layer.Interfaces
{
    public interface IUserRepository
    {
        User GetByUsername(string username);
        User GetUserById(string id);

        int Update(User entity);
        int Delete(User entity);
    }
}
