using EmployeeDetails.Model;

namespace EmployeeBlazorServerProject.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees();

        Task<Employee> GetEmployee(int id);

        Task UpdateEmployee(Employee UpdatedEmployee);
    }
}
