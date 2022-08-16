using System.Collections.Generic;

namespace CRUDApi.Models
{
    public class Employee : IEntityBase<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Profile Profile { get; set; }
        public ICollection<DevelopmentTeam> DevelopmentTeams { get; set; }
    }
}
