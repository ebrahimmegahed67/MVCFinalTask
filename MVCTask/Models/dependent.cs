using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVCTask.Models
{
    public class dependent
    {
        [ForeignKey("employee")]
        public int essn { get; set; }
        [Key]
        public string dependentName { get; set; }
        public char sex { get; set; }
        public DateTime BDate { get; set; }
        public string realation { get; set; }
        public employee employee { get; set; }
    }
}
