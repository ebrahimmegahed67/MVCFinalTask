using System.ComponentModel.DataAnnotations.Schema;

namespace MVCTask.Models
{
    public class works_on
    {
        [ForeignKey("employee")]
        public int Essn { get; set; }

        [ForeignKey("projects")]
        public int pno { get; set; }
        public int hours { get; set; }
        public employee employee { get; set; }
        public project projects { get; set; }
    }
}
