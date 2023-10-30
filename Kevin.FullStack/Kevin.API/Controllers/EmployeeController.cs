using Kevin.API.Contract.Interfaces;
using Kevin.API.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Kevin.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _employeeService.GetAllAsync();
            if (employees.Any())
                return Ok(employees);
            else
                return NotFound();
        }

        [HttpGet]
        [Route("{idEmployee}")]
        public async Task<IActionResult> GetById([FromRoute] int idEmployee)
        {
            var employeeResult = await _employeeService.GetById(idEmployee);
            if (employeeResult != null)
                return Ok(employeeResult);
            else
                return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Save(EmployeeDto employee)
        {
            var employeeResult = await _employeeService.Add(employee);
            if (employeeResult != null)
                return Ok(employeeResult);
            else
                return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPut]
        [Route("{idEmployee}")]
        public async Task<IActionResult> Update([FromRoute] int idEmployee, [FromBody] EmployeeDto employee)
        {
            var IsUpdated = await _employeeService.Update(idEmployee, employee);
            if (IsUpdated)
                return Ok(employee);
            else
                return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpDelete]
        [Route("{idEmployee}")]
        public async Task<IActionResult> Delete([FromRoute] int idEmployee)
        {
            var IsDeleted = await _employeeService.Delete(idEmployee);
            if (IsDeleted)
                return Ok();
            else
                return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
