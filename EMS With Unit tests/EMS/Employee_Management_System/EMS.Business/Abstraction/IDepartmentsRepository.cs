using EMS.Business.Entities.Models;

namespace EMS.Business.Abstraction
{
    public interface IDepartmentsRepository
    {
        Task<IEnumerable<Departments>> GetAllDepartments();
        Task<Departments> GetDepartmentById(int id);
        Task<IEnumerable<Employee>> GetEmployeeByDepartmentId(int id);
        Departments DelDepartment(int id);
    }
}
