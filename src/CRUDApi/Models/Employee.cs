using System.Collections.Generic;

namespace CRUDApi.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }

        //public string Role { get; set; }

        //public string WorkingOn { get; set; }
        public Profile Profile { get; set; }

        public ICollection<DevelopmentTeam> DevelopmentTeams { get; set; }
    }
}
