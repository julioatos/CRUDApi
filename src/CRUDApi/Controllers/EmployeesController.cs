using CRUDApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using CRUDApi.Data;
using CRUDApi.Data.Repository.Implementations;
using CRUDApi.Data.Repository.Abstractions;
using CRUDApi.Services.Abstractions;

namespace CRUDApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        List<Employee> NewEmployees = new();

        [HttpPost]
        public ActionResult CreatesEmployes(Employee newPersona)
        {
            if (newPersona is null)
                return BadRequest("The object created mustn't be empty");
            //_repository.Employee.Create(newPersona);
            //_repository.Save();
            _employeeService.CreateEmployee(newPersona);
            return Ok(newPersona);
        }

        [HttpGet]
        public async Task<IActionResult> ReturnAllEmployees()
        {
            var employees = await _employeeService.GetEmployees();

            return Ok(employees);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _employeeService.GetEmployeeById(id);

            return Ok(employee);
        }
    
    }
}
