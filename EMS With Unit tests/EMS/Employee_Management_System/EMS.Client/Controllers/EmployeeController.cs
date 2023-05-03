using EMS.Business.Abstraction;
using EMS.Business.Entities.Entity;
using EMS.Business.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Client.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployeeRepository _Repository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _Repository = employeeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                return Ok(await _Repository.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}", Name = "EmployeeById")]
        public async Task<IActionResult> EmployeeById(int id)
        {
            try
            {
                var result = await _Repository.GetById(id);
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> post(AddEmployee Data)
        {
            try
            {
                if (Data == null) return BadRequest();
                await _Repository.Add(Data);
                return CreatedAtRoute("EmployeeById", new { id = Data.Id }, Data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> put(int id, AddEmployee employee)
        {
            try
            {
                if (employee == null) return BadRequest();
                if (id != employee.Id) return BadRequest();
                await _Repository.UpdateData(id, employee);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}