using EmployeeDetails.Model;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EmployeeMangement.Api.Model
{
    public class EmployeeRepository : IEmployeeRepository
    {   
        private readonly AppDbContext _appDbContext;

        public EmployeeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Employee> AddEmployee(Employee employee)
        {
            var result = await _appDbContext.Employees.AddAsync(employee);
            await _appDbContext.SaveChangesAsync();

            return result.Entity;

        }

        public async Task<Employee> DeleteEmployee(Employee employee)
        {
            var result = await _appDbContext.Employees.FirstOrDefaultAsync
                (e => e.EmployeeId == employee.EmployeeId);

            if(result != null)
            {
                _appDbContext.Employees.Remove(result);
                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            var list = await _appDbContext.Employees.ToListAsync();

            foreach(Employee emp in list)
            {
                if(emp.EmployeeId == id)
                {
                    return emp;
                }
            }

            return null;
        }

        public async Task<Employee> GetEmail(string email)
        {
            var result = await _appDbContext.Employees.FirstOrDefaultAsync
                (e => e.Email == email);

            return result;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _appDbContext.Employees.ToListAsync();
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var result = _appDbContext.Employees.FirstOrDefault
                (e => e.EmployeeId == employee.EmployeeId);

            if(result != null)
            {
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.DateOfBirth = employee.DateOfBirth;
                result.Gender = employee.Gender;
                result.Email = employee.Email;
                result.DepartmentId  = employee.DepartmentId;
                result.PhotoPath = employee.PhotoPath;

                await _appDbContext.SaveChangesAsync();

                return result;
                
            }

            return null;
        }

        public async Task<IEnumerable<Employee>> SearchEmployees(string name, Gender? gender)
        {
            IQueryable<Employee> query = _appDbContext.Employees;

            if (!string.IsNullOrEmpty(name))
            {

                query = query.Where(e => e.FirstName.Contains(name) || e.LastName.Contains(name));
            }

            if(gender != null)
            {
                query = query.Where(e => e.Gender == gender);
            }

            return await query.ToListAsync();
        }
    }
}
