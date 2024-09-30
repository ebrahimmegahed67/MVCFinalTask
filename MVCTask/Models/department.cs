using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVCTask.Models
{
    public class department
    {
        public string dName { get; set; }

        [Key]
        public int? DNum { get; set; }
        [ForeignKey("Employee")]
        public int? MGRSSN { get; set; }
        public DateOnly MGRStartDate { get; set; }
        [InverseProperty("department")]
        public virtual List<employee>? Employees { get; set; }
        [InverseProperty("Departments")]
        public employee? Employee { get; set; }
        public virtual List<project>? Projects { get; set; }
        public virtual List<department_location>? de_locat { get; set; }
    }
}
