using System;
using System.Collections.Generic;

namespace CRUDApi.DTOs
{
    public class DevelopmentTeamReadDTO 
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Active { get; set; }
        public ICollection<EmployeeReadDTO> Employees { get; set; }
    }
}
