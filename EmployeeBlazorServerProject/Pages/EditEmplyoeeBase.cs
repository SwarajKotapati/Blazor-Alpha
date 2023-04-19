using AutoMapper;
using EmployeeBlazorServerProject.Models;
using EmployeeBlazorServerProject.Services;
using EmployeeDetails.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net;

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

        protected string PageHeader { get; set; }

        protected string FormSubmitText { get; set; }

        [CascadingParameter]
        public Task<AuthenticationState> AuthenticationStateTask { get; set; }   

        protected async override Task OnInitializedAsync()
        {

            var authenticationState = await AuthenticationStateTask;

            if (!authenticationState.User.Identity.IsAuthenticated)
            {
                string ReturnUrl = WebUtility.UrlEncode($"/EditEmployee/{Id}");
                NavigationManager.NavigateTo($"/identity/account/login?returnUrl={ReturnUrl}");
            }
            // If there is an number in the URI it means that it is a PUT request (Edit form)
            if(Id != 0)
            {
                PageHeader = "Edit Employee";
                FormSubmitText = "Save Changes";
                Employee = await EmployeeService.GetEmployee(Id);
            }
            else
            {
                // If there is no ID then its a POST req ie new employee
                // Setting up default values when the form is displayed

                Employee = new Employee()
                {
                    DepartmentId = 1,
                    DateOfBirth = DateTime.Now,
                    PhotoPath = "Images/Default.jpg",
                    Department = new Department()
                    {
                        DepartmentName = "HR"
                    },
       
                };

                PageHeader = "Create Employee";
                FormSubmitText = "Create Record";
            }

            // Even tho its POST/PUT  we want our automapper as we are using the Edit Employee data type in razor componenet
            departments = (await DepartmentService.GetDepartments()).ToList();
            populateEditEmployee();
        }

        private void populateEditEmployee()
        {
            EmployeeAutoMapper.Map(Employee, editEmployee);
        }

        public async Task SaveForm()
        {
            EmployeeAutoMapper.Map(editEmployee, Employee);

            // Edit employee request (PUT)


            if (Id != 0)
            {
                await EmployeeService.UpdateEmployee(Employee);
                NavigationManager.NavigateTo("/");

            }
            else
            {
                await EmployeeService.AddEmployee(Employee);
                NavigationManager.NavigateTo("/");

            }

        }
    }
}
