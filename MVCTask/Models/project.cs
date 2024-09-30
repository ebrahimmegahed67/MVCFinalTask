using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVCTask.Models
{
    public class project
    {
        [Key]
        public int Pnum { get; set; }
        public string Pname { get; set; }
        public string Plocation { get; set; }

        [ForeignKey("Department")]
        public int Dnum { get; set; }
        public department? Department { get; set; }
        public virtual List<works_on>? wOn { get; set; }
    }
}
