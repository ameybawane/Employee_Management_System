using EMS.Business.Abstraction;
using EMS.Business.Entities.Entity;
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
        public async Task<IActionResult> GetEmployee()
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _Repository.GetById(id);
                if (result == null)
                {
                    return NotFound();
                }
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
                await _Repository.Add(Data);
                return Ok();
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