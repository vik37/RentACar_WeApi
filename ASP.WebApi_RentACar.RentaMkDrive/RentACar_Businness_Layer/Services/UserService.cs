using Microsoft.AspNetCore.Identity;
using RentACar_Businness_Layer.Interfaces;
using RentACar_DataAccess_Layer.Interfaces;
using RentACar_DataTransfer_Layer.DTOModels;
using RentACar_Domain_Layer.Enum;
using RentACar_Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar_Businness_Layer.Services
{
    public class UserService : IUserService
    {
        protected readonly IUserRepository _userRepo;        
        protected readonly SignInManager<User> _signInManager;
        protected readonly UserManager<User> _userManager;
        protected readonly IPasswordHasher<User> _passwordHasher;
        public UserService(IUserRepository userRepo, SignInManager<User> signInManager, 
                           UserManager<User> userManager, IPasswordHasher<User> passwordHasher)
        {
            _userRepo = userRepo;
            _signInManager = signInManager;
            _userManager = userManager;
            _passwordHasher = passwordHasher;
        }

        public void Register(RegisterDto registerModel)
        {
            User user = new User()
            {
                UserName = registerModel.UserName,
                FullName = string.Format("{0} {1}", registerModel.FirstName, registerModel.LastName),
                Email = registerModel.Email,

                Orders = new List<Order>()
                {
                    new Order
                    {
                        StatusType = StatusType.Init
                    }
                }
            };
            var password = registerModel.Password;
            var result = _userManager.CreateAsync(user, password).Result;
            bool isAdmin = false;
            if (result.Succeeded)
            {
                var currentUser = _userManager.FindByNameAsync(user.UserName).Result;
                var roleResult = _userManager.AddToRoleAsync(currentUser, "user").Result;
                if (roleResult.Succeeded)
                {
                    LogIn(new LoginDto
                    {
                        UserName = registerModel.UserName,
                        Password = registerModel.Password
                    },out isAdmin);
                }
                else
                {
                    throw new Exception("Adding user to a role failed!");
                }
                
            }
        }
        public void LogIn(LoginDto loginModel, out bool isAdmin)
        {
            var result = _signInManager.PasswordSignInAsync(loginModel.UserName, loginModel.Password, false, false).Result;
            User user = _userRepo.GetByUsername(loginModel.UserName);
            isAdmin = false;
            if (result.Succeeded)
            {
                isAdmin = _userManager.IsInRoleAsync(user, "admin").Result;
            }
            if (result.IsNotAllowed)
            {
                throw new Exception("Username or Password is not correct!");
            }
            
        }
        public UserDto GetCurrentUser(string username)
        {
            try
            {
                User user = _userRepo.GetByUsername(username);
                return new UserDto
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    FullName = user.FullName
                };
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw new Exception(message);
            }
        }
        public void Update(string id, RegisterDto model)
        {
            var user = _userManager.FindByIdAsync(id).Result;
            if(user != null)
            {
                if (!string.IsNullOrEmpty(model.Email))
                {
                    user.Email = model.Email;                    
                }
                else
                {
                    throw new Exception("Email can not be empty");
                }
                if (!string.IsNullOrEmpty(model.UserName))
                {
                    user.UserName = model.UserName;
                }
                else
                {
                    throw new Exception("Username can not be empty");
                }
                if (!string.IsNullOrEmpty(model.Password))
                {
                    user.PasswordHash = _passwordHasher.HashPassword(user, model.Password);
                }
                else
                {
                    throw new Exception("Email can not be empty");
                }
                var result = _userManager.UpdateAsync(user).Result;
                if (!result.Succeeded)
                {
                    throw new Exception("Something wrong. Please try again!");
                }
            }
            else
            {
                throw new Exception("User not found!");
            }
            
        }
        
        public void LogOut()
        {
            _signInManager.SignOutAsync();
        }

       
    }
}
