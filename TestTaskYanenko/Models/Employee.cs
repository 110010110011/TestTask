using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TestTaskYanenko.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public int DateBirthday { get; set; }

        public string Sex { get; set; }

        [ForeignKey("ActivityId")]
        public int ActivityId { get; set; }

        public List<Activity> Activities { get; set; }
    }
}
