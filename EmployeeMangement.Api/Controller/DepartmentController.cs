using EmployeeDetails.Model;
using EmployeeMangement.Api.Model;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMangement.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]


    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _IDepartmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _IDepartmentRepository = departmentRepository;
        }

        [HttpGet]

        public async Task<ActionResult> GetDepartments()
        {
            try
            {
                return Ok(await _IDepartmentRepository.GetDepartments());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Sorry our server isn't responding");
            }
            
        }

        [HttpGet("{id:int}")]

        public async Task<ActionResult<Department>> GetDepartmentById(int id)
        {
            try
            {
                var result = await _IDepartmentRepository.GetDepartmentById(id);

                if(result != null)
                {
                    return result;
                }
                return NotFound();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Sorry our server isn't responding");
            }
        }
    }
}
