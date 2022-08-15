using System;
using System.Collections.Generic;

namespace CRUDApi.Models
{
    public class DevelopmentTeam
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }

        public bool Active { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
