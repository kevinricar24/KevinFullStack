using Kevin.API.Contract.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kevin.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var departments = await _departmentService.GetAllAsync();
            if (departments.Any())
                return Ok(departments);
            else
                return NotFound();

        }
    }
}
