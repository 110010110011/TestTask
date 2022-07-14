using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TestTaskYanenko.Models
{
    public class Activity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("RoleId")]
        public int RoleId { get; set; }
        
        public Role Role { get; set; }

        [ForeignKey("ProjectId")]
        public int ProjectId { get; set; }
        
        public Project Project { get; set; }

        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }
        
        public Employee Employee { get; set; }

        [ForeignKey("ActivityTypeId")]
        public int ActivityTypeId { get; set; }
        
        public ActivityType ActivityType { get; set; }
    }
}
