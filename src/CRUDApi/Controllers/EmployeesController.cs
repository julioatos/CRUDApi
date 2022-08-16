using CRUDApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using CRUDApi.Data;
using CRUDApi.Data.Repository.Implementations;
using CRUDApi.Data.Repository.Abstractions;

namespace CRUDApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private readonly ScrumTeamContext _context;
        private IRepositoryWrapper _repository;

        public EmployeesController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }
        
        List<Employee> NewEmployees = new();

        [HttpPost]
        public async Task<IActionResult> CreatesEmployes(Employee newPersona)
        {
            if (newPersona is null)
                return BadRequest("The object created mustn't be empty");
            _repository.Employee.Create(newPersona);
            _repository.Save();
            return Ok(newPersona);
        }

        [HttpGet]
        public async Task<IActionResult> ReturnAllEmployees()
        {
            var employees = await _repository.Employee.GetAll();
            if(employees is null)
                return NotFound("Not founded");
            return Ok(employees);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> RerturnEmployeeByID(int id)
        {
            var employee = await _repository.Employee.GetById(id);
            if (employee is null)
                return NotFound("Employee not founded");
            return Ok(employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmplooye(int id)
        {
            var employee = await _repository.Employee.GetById(id);
            if (employee is null)
                return NotFound("Employee not founded");
            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            DevelopmentTeam DevTeam = new() { Active = true, Id = 1, CreationDate = System.DateTime.Now };
            DevelopmentTeam DevTeam2 = new() { Active= false, Id = 2, CreationDate = System.DateTime.Today };

            ICollection<DevelopmentTeam> MyCollection = new List<DevelopmentTeam>() { DevTeam, DevTeam2 };

            Profile NewProfile = new() { EmployeeId = 0, Id = 0, ProfileName = "Backend Developer" };
            Profile NewProfile2 = new() { EmployeeId = 1, Id = 1, ProfileName = "QA Tester" };

            Employee MyEmployee = new()
            {
                DevelopmentTeams = MyCollection,
                Id = 0,
                Name = "Julio",
                Profile = NewProfile
            };

            Employee MyEmployee2 = new()
            {
                DevelopmentTeams = MyCollection,
                Id = 1,
                Name = "Jaime",
                Profile = NewProfile2
            };

            NewEmployees.Add(MyEmployee);
            NewEmployees.Add(MyEmployee2);
            //NewEmployees.FirstOrDefault(s => s.EmployeeId == id)
            NewEmployees.RemoveAt(id)/*FirstOrDefault(s => s.EmployeeId == id)*/;
            return Ok(NewEmployees);
        }

    }
}
