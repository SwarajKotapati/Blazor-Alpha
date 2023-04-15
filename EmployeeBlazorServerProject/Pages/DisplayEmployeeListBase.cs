using EmployeeBlazorServerProject.Services;
using EmployeeDetails.Model;
using Microsoft.AspNetCore.Components;

namespace EmployeeBlazorServerProject.Pages
{
    public class DisplayEmployeeListBase : ComponentBase
    {
        [Parameter]
        public Employee Employee { get; set; }

        [Parameter]
        public bool ShowOptions { get; set; } = true;

        [Parameter]
        public EventCallback<bool> EventCallback { get; set; }

        [Parameter]
        public EventCallback<bool> DeleteEventCallback { get; set; }

        [Inject]

        protected IEmployeeService EmployeeService { get; set; }

        [Inject]

        protected NavigationManager NavigationManager { get; set; }

        public bool IsChecked {get; set; }
        
        public async Task CheckBoxChanged(ChangeEventArgs e)
        {
            IsChecked = (bool)e.Value;
            await EventCallback.InvokeAsync(IsChecked);
        }

        public async Task DeleteEmployee()
        {
            await EmployeeService.DeleteEmployee(Employee.EmployeeId);
            await DeleteEventCallback.InvokeAsync(true);


            //We are no longer force realoading the page, rather we are invoking an event call back
            //NavigationManager.NavigateTo("/", true);
        }



    }
}
