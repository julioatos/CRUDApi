using CRUDApi.Models;
using System.Collections.Generic;

namespace CRUDApi.DTOs
{
    public class EmployeeReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProfileReadDTO Profile { get; set; }
        public ICollection<DevelopmentTeam> DevelopmentTeams { get; set; }

    }
}
