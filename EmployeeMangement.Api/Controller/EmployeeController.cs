using EmployeeDetails.Model;
using EmployeeMangement.Api.Model;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMangement.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]

    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _IEmployeeRepository;
        public EmployeeController(IEmployeeRepository IEmployeeRepository)
        {
            _IEmployeeRepository = IEmployeeRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetEmployees()
        {

            try
            {
                return Ok(await _IEmployeeRepository.GetEmployees());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Sorry our server isnt listening to us !");
            }

        }

        [HttpGet("{id:int}")]

        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {

            try
            {
                var result = await _IEmployeeRepository.GetEmployee(id);

                if (result != null)
                {
                    return result;
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Sorry our server isnt listening to us !");
            }

        }

        [HttpPost]

        public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
        {
            try
            {
                if (employee == null)
                {
                    return BadRequest();
                }

                var emailCheck = await _IEmployeeRepository.GetEmail(employee.Email);

                if (emailCheck != null)
                {
                    ModelState.AddModelError("Email error", "Email Address already in use");
                    return BadRequest(ModelState);
                }
                var result = await _IEmployeeRepository.AddEmployee(employee);

                //return CreatedAtAction(nameof(GetEmployee), new {id = result.EmployeeId},result);
                return CreatedAtAction(nameof(AddEmployee), result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Sorry our server isnt listening to us !");
            }

        }

        [HttpPut("{id:int}")]

        public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee employee)
        {

            try
            {

                if(id != employee.EmployeeId)
                {
                    return BadRequest("Employee Id mismatch");
                }

                var employeeToUpdate = await _IEmployeeRepository.GetEmployee(id);

                if(employeeToUpdate == null)
                {
                    return BadRequest($"Employee not found with id = {id}");
                }

                var result = await _IEmployeeRepository.UpdateEmployee(employee);
                return result;

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Sorry our server isnt updating your data !");
            }

        }

        [HttpDelete("{id:int}")]

        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            var EmpToDelete = await _IEmployeeRepository.GetEmployee(id);

            if(EmpToDelete == null)
            {
                return BadRequest($"Id{id} Not Found");
            }
            return await _IEmployeeRepository.DeleteEmployee(EmpToDelete);
        }
    }
}
