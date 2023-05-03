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

        public async Task<IEnumerable<Departments>> GetAllDepartments()
        {
            return await _department.departments.ToListAsync();
        }

        public async Task<Departments> GetDepartmentById(int id)
        {
            var result = await _department.departments.FindAsync(id);
            if (result == null)
                return null;
            return result;
        }

        public async Task<IEnumerable<Employee>> GetEmployeeByDepartmentId(int id)
        {
            var result = await (from e in _department.employees
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
            return result;
        }

        public Departments DelDepartment(int id)
        {
            var result = _department.departments.Find(id);
            if (result == null) return null;
            if (result.IsActive == false)
            {
                _department.departments.Remove(result);
                _department.SaveChanges();
                return result;
            }
            else
            {
                var resultList = _department.employees.Where(e => e.DepartmentId == id).ToList();
                if(resultList.Count <= 0)
                {
                    _department.departments.Remove(result);
                    _department.SaveChanges();
                    return result;
                }
            }
            return null;
        }
    }
}
