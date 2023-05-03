using EMS.Business.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Client.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        IDepartmentsRepository _Repository;
        public DepartmentsController(IDepartmentsRepository departmentsRepository)
        {
            _Repository = departmentsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> AllDepartments()
        {
            try
            {
                return Ok(await _Repository.GetAllDepartments());
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> DepartmentById(int id)
        {
            try
            {
                var result = await _Repository.GetDepartmentById(id);
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}/Employee")]
        public async Task<IActionResult> EmployeeByDepartmentId(int id)
        {
            try
            {
                var result = await _Repository.GetEmployeeByDepartmentId(id);
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            try
            {
                var result = _Repository.DelDepartment(id);
                if (result == null)
                {
                    return BadRequest();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
