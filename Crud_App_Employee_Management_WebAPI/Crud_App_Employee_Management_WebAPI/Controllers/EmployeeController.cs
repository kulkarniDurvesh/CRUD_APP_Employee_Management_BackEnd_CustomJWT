using JWTAuthenticationAuthorization.JwtModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using ServiceLayer;

namespace Crud_App_Employee_Management_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorization(Role.Customer)]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeServices _employeeServices;

        public EmployeeController(EmployeeServices employeeServices)
        {
            _employeeServices = employeeServices;
        }

        [HttpGet("GetAllEmployees")]
        public async Task<IActionResult> GetAllEmployees() {
            return (Ok(await _employeeServices.GetAllEmployessList()));
        }

        
        [HttpGet("age")]
        public async Task<IActionResult> GetAllEmployeeByAge(int age) { 
            return Ok(await _employeeServices.GetAllEmployeesByAge(age));
        }

        [HttpPost("AddEmployee")]
        public IActionResult AddEmployee(EmployeeClass employee) 
        {

            return Ok( _employeeServices.AddEmployee(employee));
        }

        [HttpPut("UpdateEmployee")]
        public IActionResult UpdateEmployeeDetails(EmployeeClass employee)
        {

            return Ok(_employeeServices.UpdateEmployeeDetails(employee));
        }

    }
}
