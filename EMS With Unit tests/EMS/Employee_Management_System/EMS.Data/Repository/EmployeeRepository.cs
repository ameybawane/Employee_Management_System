using EMS.Business.Abstraction;
using EMS.Business.Entities.Entity;
using EMS.Business.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace EMS.Data.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DatabaseContext _employee;
        public EmployeeRepository(DatabaseContext employeeRepository)
        {
            _employee = employeeRepository;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await(from e in _employee.employees
                         from d in _employee.departments
                         where e.DepartmentId == d.Id && e.IsActive == true
                         orderby e.DepartmentId
                         select new Employee
                         {
                             Id = e.Id,
                             FirstName = e.FirstName,
                             LastName = e.LastName,
                             Email = e.Email,
                             DateOfBirth = e.DateOfBirth,
                             Age = e.Age,
                             IsActive = e.IsActive,
                             JoinedDate = e.JoinedDate,
                             DepartmentId = e.DepartmentId
                         }).ToListAsync();
        }

        public async Task<Employee> GetById(int id)
        {
            var result = await _employee.employees.FindAsync(id);
            if (result == null)
                return null;
            return result;
        }

        public Task Add(AddEmployee Data)
        {
            var data = new Employee()
            {
                FirstName = Data.FirstName,
                LastName = Data.LastName,
                DateOfBirth = Data.DateOfBirth,
                Age = Data.Age,
                IsActive = Data.IsActive,
                Email = Data.Email,
                DepartmentId = Data.DepartmentId
            };
            _employee.employees.AddAsync(data);
            return _employee.SaveChangesAsync();
        }

        public async Task UpdateData(int id, AddEmployee updateEmployee)
        {
            var employeeData = await _employee.employees.FindAsync(id);
            if (employeeData != null)
            {
                employeeData.Id = updateEmployee.Id;
                employeeData.FirstName = updateEmployee.FirstName;
                employeeData.LastName = updateEmployee.LastName;
                employeeData.DateOfBirth = updateEmployee.DateOfBirth;
                employeeData.Age = updateEmployee.Age;
                employeeData.IsActive = updateEmployee.IsActive;
                employeeData.JoinedDate = updateEmployee.JoinedDate;
                employeeData.Email = updateEmployee.Email;
                employeeData.DepartmentId = updateEmployee.DepartmentId;
                _employee.employees.Update(employeeData);
                await _employee.SaveChangesAsync();
            };
        }
    }
}
