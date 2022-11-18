using EMS.Business.Abstraction;
using EMS.Business.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace EMS.Data.Repository
{
    public class DepartmentsRepository : IDepartmentsRepository
    {
        private readonly DatabaseContext _department;
        public DepartmentsRepository(DatabaseContext departmentsRepository)
        {
            _department = departmentsRepository;
        }

        public async Task<IEnumerable<Departments>> GetAllDept()
        {

            return await _department.departments.ToListAsync();
        }

        public async Task<Departments> GetDeptById(int id)
        {
            var result= await _department.departments.FindAsync(id);
            if (result == null)
                return null;
            return result;
        }

        public async Task<IEnumerable<Employee>> GetEmpByDeptId(int id)
        {
            return await (from e in _department.employees
                          where e.DepartmentId == id 
                          select new Employee
                          {
                              Id = e.Id,
                              FirstName = e.FirstName,
                              LastName = e.LastName,
                              Email = e.Email,
                              DateOfBirth = e.DateOfBirth,
                              Age = e.Age,
                              JoinedDate = e.JoinedDate,
                              IsActive = e.IsActive,
                              DepartmentId = e.DepartmentId
                          }).ToListAsync();
        }

        public string DelDept(int id)
        {
            var result = _department.departments.Find(id);
            if (result == null) return "Invalid Id";
            if (result.IsActive == false)
            {
                _department.departments.Remove(result);
                _department.SaveChanges();
                return "Deleted";
            }
            else
            {
                var a = _department.employees.Where(x => x.DepartmentId == id).FirstOrDefault();
                if (a == null)
                {
                    var b = _department.departments.Find(id);
                    _department.departments.Remove(b);
                    _department.SaveChanges();
                    return "Deleted";
                }
            }
            return null;
        }
    }
}
