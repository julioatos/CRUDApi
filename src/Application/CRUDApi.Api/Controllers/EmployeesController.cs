using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CRUDApi.Services.Abstractions;
using CRUDApi.DTOs;
using CRUDApi.Exceptions;
using Microsoft.AspNetCore.Authorization;

namespace CRUDApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatesEmployes(EmployeeCreateDTO newPersona)
        {
            if (newPersona is null)
                return BadRequest("The object created mustn't be empty");
            try
            {
                await _employeeService.CreateEmployeeAsync(newPersona);
            }
            catch (EntityNotFoundException)
            {
                return NotFound("Profile doesn't exists");
            }
            catch (NameAlreadyExistException)
            {
                return BadRequest("The name already exists in the database");
            }
            return Ok(newPersona);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> ReturnAllEmployees()
        {
            var employees = await _employeeService.GetEmployees();
            if (employees.Count < 1)
                return NotFound("There isn't employees reistered");
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _employeeService.GetEmployeeById(id);
            if (employee is null)
                return NotFound("The employee doesn't exists");
            return Ok(employee);
        }

    }
}
