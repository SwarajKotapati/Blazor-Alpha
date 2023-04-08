using EmployeeDetails.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMangement.Api.Model
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _appDbContext;

        public DepartmentRepository (AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Department> GetDepartmentById(int id)
        {
            var result = await _appDbContext.Departments.FirstOrDefaultAsync
                (d => d.DepartmentId == id);

            return result;
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await _appDbContext.Departments.ToListAsync();
        }
    }
}
