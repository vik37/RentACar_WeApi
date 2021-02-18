using RentACar_DataTransfer_Layer.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar_Businness_Layer.Interfaces
{
    public interface IUserService
    {
        void Register(RegisterDto registerModel);
        void LogIn(LoginDto loginModel, out bool isAdmin);
        void LogOut();
        UserDto GetCurrentUser(string username);

        void Update(string id, RegisterDto model);
        
    }
}
