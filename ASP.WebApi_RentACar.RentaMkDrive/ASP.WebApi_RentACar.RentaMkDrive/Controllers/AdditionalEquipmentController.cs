using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar_Businness_Layer.Exceptions;
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
    public class AdditionalEquipmentController : ControllerBase
    {
        private readonly IAddEquipmentService _equipment;
        public AdditionalEquipmentController(IAddEquipmentService equipment)
        {
            _equipment = equipment;
        }

        [HttpGet]
        public ActionResult<AddEquipmentDto> Get()
        {
            try
            {
                return Ok(_equipment.GetAll());
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<AddEquipmentDto> Get(int id)
        {
            try
            {
                return Ok(_equipment.GetById(id));
            }
            catch(AddEquipmentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        public ActionResult<AdditionalEquipment> AddEquipment([FromBody] AddEquipmentDto equipment)
        {
            try
            {
                _equipment.Add(equipment);
                return Ok("New equipment is successfuly added");
            }
            catch(AddEquipmentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] AddEquipmentDto equipment)
        {
            try
            {
                
                _equipment.Update(equipment);

                return Ok("Equipment changes is successfully!");
            }
            catch (AddEquipmentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult<AdditionalEquipment> Remove(int id)
        {
            try
            {
                _equipment.Remove(id);
                return Ok("Equipment success deleted");
            }
            catch(AddEquipmentException ex)
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
