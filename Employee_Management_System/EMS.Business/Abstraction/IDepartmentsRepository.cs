using EMS.Business.Entities.Models;

namespace EMS.Business.Abstraction
{
    public interface IDepartmentsRepository
    {
        Task<IEnumerable<Departments>> GetAllDept();
        Task<Departments> GetDeptById(int id);
        Task<IEnumerable<Employee>> GetEmpByDeptId(int id);
        string DelDept(int id);
    }
}
