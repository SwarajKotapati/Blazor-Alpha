using EmployeeDetails.Model;

namespace EmployeeBlazorServerProject.Services
{
    public interface IDepartmentService
    {

        Task<IEnumerable<Department>> GetDepartments();

        Task<Department> GetDepartmentById(int id);
    }
}
