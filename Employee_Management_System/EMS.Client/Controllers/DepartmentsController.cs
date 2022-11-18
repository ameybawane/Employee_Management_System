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
        public async Task<IActionResult> GetAllDepartments()
        {
            try
            {
                return Ok(await _Repository.GetAllDept());
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            try
            {
                var result = await _Repository.GetDeptById(id);
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

        [HttpGet("{id}/Employee")]
        public async Task<IActionResult> GetEmployeeByDepartmentId(int id)
        {
            try
            {
                return Ok(await _Repository.GetEmpByDeptId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteDepartment(int id)
        {
            try
            {
                var result = _Repository.DelDept(id);
                if (result == null)
                {
                    return BadRequest();
                }
                else if (result.Equals("Invalid Id"))
                {
                    return NotFound();
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
