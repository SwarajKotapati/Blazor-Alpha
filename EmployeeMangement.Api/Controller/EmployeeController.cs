﻿using EmployeeDetails.Model;
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

        public async Task<ActionResult> AddEmployee(Employee employee)
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

        [HttpPut]

        public async Task<ActionResult<Employee>> UpdateEmployee(Employee employee)
        {

            try
            {

                var employeeToUpdate = await _IEmployeeRepository.GetEmployee(employee.EmployeeId);

                if(employeeToUpdate == null)
                {
                    return BadRequest($"Employee not found with id = {employee.EmployeeId}");
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

            try
            {
                var EmpToDelete = await _IEmployeeRepository.GetEmployee(id);

                if (EmpToDelete == null)
                {
                    return BadRequest($"Id{id} Not Found");
                }
                return await _IEmployeeRepository.DeleteEmployee(EmpToDelete);
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Sorry our server isnt deleting your data !");
            }
            
        }

        [HttpGet("search")]

        public async Task<ActionResult<IEnumerable<Employee>>> SearchEmployees(String name,Gender ? gender)
        {
            try
            {
                var result = await _IEmployeeRepository.SearchEmployees(name,gender);

                if(result.Any())
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Sorry our server isnt responding !");
            }
        }
    }
}
