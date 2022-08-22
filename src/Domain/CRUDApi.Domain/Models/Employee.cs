using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRUDApi.Models
{
    public class Employee : IEntityBase<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ProfileId { get; set; }
        public Profile? Profile { get; set; }
        public ICollection<DevelopmentTeam> DevelopmentTeams { get; set; }
    }
}
