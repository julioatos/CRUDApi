using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDApi.Models
{
    public class Profile
    {
        //[ForeignKey("Employee")]
        public int Id { get; set; }
        public string ProfileName { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
