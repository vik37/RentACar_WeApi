using RentACar_DataAccess_Layer.Interfaces;
using RentACar_Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentACar_DataAccess_Layer.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(RentaCarDbContext context) : base(context) { }

        public IEnumerable<User> GetAll()
        {
            return _db.Users;
        }
        
        public User GetUserById(string id)
        {
            return _db.Users.SingleOrDefault(u => u.Id == id);
        }

        public User GetByUsername(string username)
        {
            return _db.Users.SingleOrDefault(u => u.UserName == username);
        }

        
        public int Update(User entity)
        {
            _db.Users.Update(entity);
            return _db.SaveChanges();
        }
        public int Delete(User entity)
        {
            User user = _db.Users.SingleOrDefault(u => u.Id == entity.Id);

            if (user == null)
                return -1;
            _db.Users.Remove(user);
            return _db.SaveChanges();
        }
    }
}
