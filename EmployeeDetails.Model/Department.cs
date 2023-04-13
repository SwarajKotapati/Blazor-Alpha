using System.ComponentModel.DataAnnotations;

namespace EmployeeDetails.Model
{
    public class Department
    {
        public int DepartmentId { get; set; }

        [Required]
        [MinLength(2)]
        public string DepartmentName { get; set; }
    }
}