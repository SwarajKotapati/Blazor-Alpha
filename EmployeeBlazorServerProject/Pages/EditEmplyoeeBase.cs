using EmployeeBlazorServerProject.Services;
using EmployeeDetails.Model;
using Microsoft.AspNetCore.Components;

namespace EmployeeBlazorServerProject.Pages
{
    public class EditEmplyoeeBase : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }
        
        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        [Inject]

        public IDepartmentService DepartmentService { get; set; }   

        public Employee Employee { get; set; } = new Employee();

        public List<Department> departments { get; set; } = new List<Department>();

        protected async override Task OnInitializedAsync()
        {
            Employee = await EmployeeService.GetEmployee(Id);
            departments = (await DepartmentService.GetDepartments()).ToList();
        }
    }
}
