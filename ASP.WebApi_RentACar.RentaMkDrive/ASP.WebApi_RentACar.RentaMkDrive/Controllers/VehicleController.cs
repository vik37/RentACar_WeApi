using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar_Businness_Layer.Exceptions;
using RentACar_Businness_Layer.Interfaces;
using RentACar_Businness_Layer.Services;
using RentACar_DataTransfer_Layer.DTOModels;
using RentACar_DataTransfer_Layer.Enums;
using RentACar_Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.WebApi_RentACar.RentaMkDrive.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        public ActionResult<List<VehicleDto>> Get()
        {
            try
            {
                var vehicle = _vehicleService.GetAllVehicles();
                return Ok(vehicle);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<VehicleDto> Get(int id)
        {
            try
            {
                return Ok(_vehicleService.GetVehicleById(id));
            }
            catch(VehicleException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("type")]
        public ActionResult<VehicleDto> Gettype(int type)
        {
            try
            {

                //VehicleTypeDto typeVehicle = (VehicleTypeDto) Enum.Parse(typeof(VehicleTypeDto),type);
                VehicleTypeDto typeVehicle = (VehicleTypeDto)type;
                return Ok(_vehicleService.GetVehiclesByType(typeVehicle));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        public ActionResult<Vehicle> AddVehicle([FromBody] VehicleDto vehicle)
        {
            try
            {
                _vehicleService.AddVehicle(vehicle);
                return Ok("New vehicle is add success!");
            }
            catch(VehicleException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult<Vehicle> RemoveVehicle(int id)
        {
            try
            {
                _vehicleService.RemoveVehicle(id);
                return Ok("Vehicle successed deleted!");
            }
            catch(VehicleException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut("{id}")]
        public ActionResult Put(int id,[FromBody] VehicleDto vehicle)
        {
            try
            {                
                _vehicleService.UpdateVehicle(vehicle);
                return Ok("Vehicle changes is successfully!");
            }
            catch(VehicleException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }

    
}
