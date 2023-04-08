using EmployeeDetails.Model;

namespace EmployeeMangement.Api.Model
{
    public interface IEmployeeRepository
    {

        Task<IEnumerable<Employee>> GetEmployees();

        Task <Employee> GetEmployee(int id);

        Task<Employee> GetEmail(string  email);

        Task <Employee> UpdateEmployee(Employee employee);

        Task <Employee> AddEmployee(Employee employee);

        void DeleteEmployee(Employee employee);

    }
}
