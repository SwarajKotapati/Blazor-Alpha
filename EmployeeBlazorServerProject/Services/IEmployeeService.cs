using EmployeeDetails.Model;

namespace EmployeeBlazorServerProject.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees();
    }
}
