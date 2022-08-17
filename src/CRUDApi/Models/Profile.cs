using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDApi.Models
{
    public class Profile : IEntityBase<int>
    {
        //[ForeignKey("Employee")]
        public int Id { get; set; }
        public string ProfileName { get; set; }
    }
}
