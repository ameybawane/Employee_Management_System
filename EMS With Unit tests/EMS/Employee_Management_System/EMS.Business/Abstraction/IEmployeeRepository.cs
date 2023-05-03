using EMS.Business.Entities.Entity;
using EMS.Business.Entities.Models;

namespace EMS.Business.Abstraction
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee> GetById(int id);
        Task Add(AddEmployee Data);
        Task UpdateData(int id, AddEmployee entity);
    }
}
