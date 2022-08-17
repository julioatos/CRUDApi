using System;
using System.Collections.Generic;

namespace CRUDApi.DTOs
{
    public class DevelopmentTeamCreateDTO
    {
        public DateTime CreationDate { get; set; }
        public bool Active { get; set; }
        public List<int> EmployesId { get; set; }
    }
}
