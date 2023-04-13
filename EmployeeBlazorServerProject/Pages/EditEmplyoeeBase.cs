using AutoMapper;
using EmployeeBlazorServerProject.Models;
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

        [Inject]

        public IMapper EmployeeAutoMapper { get; set; }

        [Inject]

        public NavigationManager NavigationManager { get; set; }

        private Employee Employee { get; set; } = new Employee();

        public EditEmplyoeeModel editEmployee { get; set; } = new EditEmplyoeeModel();

        public List<Department> departments { get; set; } = new List<Department>();

        protected async override Task OnInitializedAsync()
        {
            Employee = await EmployeeService.GetEmployee(Id);
            departments = (await DepartmentService.GetDepartments()).ToList();

            populateEditEmployee();
        }

        private void populateEditEmployee()
        {
            EmployeeAutoMapper.Map(Employee, editEmployee);
        }

        public void SaveForm()
        {
            EmployeeAutoMapper.Map(editEmployee, Employee);

            var result = EmployeeService.UpdateEmployee(Employee);

            if(result != null)
            {
                NavigationManager.NavigateTo("/");
            }
        }
    }
}
