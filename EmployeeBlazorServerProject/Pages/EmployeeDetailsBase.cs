using EmployeeBlazorServerProject.Services;
using EmployeeDetails.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeBlazorServerProject.Pages
{
    public class EmployeeDetailsBase : ComponentBase
    {
        [Parameter]
        public string Id { get; set; }

        [Inject]
        private IEmployeeService _IemployeeService {get; set;}

        protected Employee Employee { get; set; } = new Employee();

        protected string FontFamily = "Verdana";

        protected string Cordinates { get; set; }

        protected string CordinatesClass { get; set; }

        protected string CordinatesButttonText { get; set; }

        protected string CordinatesButtonClass { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Employee = await _IemployeeService.GetEmployee(int.Parse(Id));
            
            
            CordinatesButttonText = "Show Cordinates";
            CordinatesClass = "hideDisplay";
            CordinatesButtonClass = "btn btn-success";

        }

        protected void MouseCordinates(MouseEventArgs mouseEventArgs)
        {
            Cordinates =  $" X = {mouseEventArgs.ClientX}  , Y = {mouseEventArgs.ClientY}";
        }

        protected void DisplayCordinates()
        {
            //When displaying cordinates, we turn them off
            if(CordinatesClass == null)
            {
                CordinatesClass = "hideDisplay";
                CordinatesButttonText = "Show Cordinates";
                CordinatesButtonClass = "btn btn-success";

            }
            else
            {
                CordinatesClass = null;
                CordinatesButttonText = "Hide Cordinates";
                CordinatesButtonClass = "btn btn-dark";
            }
        }
    }
}
