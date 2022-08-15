using CRUDApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace CRUDApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        
        List<Employee> NewEmployees = new();

        [HttpPost]
        public async Task<IActionResult> CreatesEmployes(/*Employee newPersona*/)
        {
            return Ok(NewEmployees);
        }

        [HttpGet]
        public async Task<IActionResult> ReturnAllEmployees()
        {
            //DevelopmentTeam DevTeam = new() {Active = true, Id = 1, CreationDate = System.DateTime.Now};
            //DevelopmentTeam DevTeam2 = new() {Active= false, Id = 2, CreationDate = System.DateTime.Today};

            //ICollection<DevelopmentTeam> MyCollection = new List<DevelopmentTeam>() {DevTeam, DevTeam2};

            //Profile NewProfile = new() { EmployeeId = 0, Id = 0, ProfileName = "Backend Developer"};
            //Profile NewProfile2 = new() { EmployeeId = 1, Id = 1, ProfileName = "QA Tester"};

            //Employee MyEmployee = new()
            //{
            //    DevelopmentTeams = MyCollection,
            //    EmployeeId = 0,
            //    Name = "Julio",
            //    Profile = NewProfile
            //};

            //Employee MyEmployee2 = new()
            //{
            //    DevelopmentTeams = MyCollection,
            //    EmployeeId = 1,
            //    Name = "Jaime",
            //    Profile = NewProfile2
            //};

            //NewEmployees.Add(MyEmployee);
            //NewEmployees.Add(MyEmployee2);

            return Ok(NewEmployees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> RerturnEmployeeByID(int id)
        {
            //DevelopmentTeam DevTeam = new() { Active = true, Id = 1, CreationDate = System.DateTime.Now };
            //DevelopmentTeam DevTeam2 = new() { Active= false, Id = 2, CreationDate = System.DateTime.Today };

            //ICollection<DevelopmentTeam> MyCollection = new List<DevelopmentTeam>() { DevTeam, DevTeam2 };

            //Profile NewProfile = new() { EmployeeId = 0, Id = 0, ProfileName = "Backend Developer" };
            //Profile NewProfile2 = new() { EmployeeId = 1, Id = 1, ProfileName = "QA Tester" };

            //Employee MyEmployee = new()
            //{
            //    DevelopmentTeams = MyCollection,
            //    EmployeeId = 0,
            //    Name = "Julio",
            //    Profile = NewProfile
            //};

            //Employee MyEmployee2 = new()
            //{
            //    DevelopmentTeams = MyCollection,
            //    EmployeeId = 1,
            //    Name = "Jaime",
            //    Profile = NewProfile2
            //};

            //NewEmployees.Add(MyEmployee);
            //NewEmployees.Add(MyEmployee2);
            return Ok(NewEmployees.FirstOrDefault(s => s.EmployeeId == id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmplooye(int id, string name)
        {
            //DevelopmentTeam DevTeam = new() { Active = true, Id = 1, CreationDate = System.DateTime.Now };
            //DevelopmentTeam DevTeam2 = new() { Active= false, Id = 2, CreationDate = System.DateTime.Today };

            //ICollection<DevelopmentTeam> MyCollection = new List<DevelopmentTeam>() { DevTeam, DevTeam2 };

            //Profile NewProfile = new() { EmployeeId = 0, Id = 0, ProfileName = "Backend Developer" };
            //Profile NewProfile2 = new() { EmployeeId = 1, Id = 1, ProfileName = "QA Tester" };

            //Employee MyEmployee = new()
            //{
            //    DevelopmentTeams = MyCollection,
            //    EmployeeId = 0,
            //    Name = "Julio",
            //    Profile = NewProfile
            //};

            //Employee MyEmployee2 = new()
            //{
            //    DevelopmentTeams = MyCollection,
            //    EmployeeId = 1,
            //    Name = "Jaime",
            //    Profile = NewProfile2
            //};

            //NewEmployees.Add(MyEmployee);
            //NewEmployees.Add(MyEmployee2);
            ////NewEmployees.FirstOrDefault(s => s.EmployeeId == id)
            //NewEmployees.FirstOrDefault(s => s.EmployeeId == id).Name = name;
            return Ok(NewEmployees.FirstOrDefault(s => s.EmployeeId == id));
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
                EmployeeId = 0,
                Name = "Julio",
                Profile = NewProfile
            };

            Employee MyEmployee2 = new()
            {
                DevelopmentTeams = MyCollection,
                EmployeeId = 1,
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
