using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar_Businness_Layer.Interfaces;
using RentACar_DataTransfer_Layer.DTOModels;
using RentACar_Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.WebApi_RentACar.RentaMkDrive.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("username")]
        public ActionResult<UserDto> Get(string username)
        {
            try
            {
                var user = _userService.GetCurrentUser(username);
                if (user == null)
                    return BadRequest("Invalid username");
                return Ok(user);

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            
        }
        [HttpPost("register")]
        public ActionResult<UserDto> Register([FromBody] RegisterDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _userService.Register(model);
                    return Ok("Register successed!");
                }
                else
                {
                    return BadRequest("Something wrong!");
                }
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost("Login")]
        public ActionResult<LoginDto> Login([FromBody] LoginDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isAdmin;
                    _userService.LogIn(model, out isAdmin);
                    if (isAdmin)
                    {
                        return Ok($"Login with username {model.UserName} is successed as Admin user");
                    }
                    else
                    {
                        return Ok($"Login with username {model.UserName} is successed as Costumare user");
                    }
                }
                return BadRequest("Model state is not valid");
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut("edit")]
        public ActionResult Put(string id, [FromBody] RegisterDto model)
        {
            try
            {
                _userService.Update(id,model);
                return Ok("Your edit is successfully!");
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
       
        [HttpGet("logout")]
        public ActionResult Logout()
        {
            _userService.LogOut();
            return Ok("Log out successed");
        }
    }
}
