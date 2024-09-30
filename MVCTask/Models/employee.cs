using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace MVCTask.Models
{
    public class employee
    {
        [Key]
        public int ssn { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "must at least 3 char")]
        [uniqueName]
        public string? fName { get; set; }
        [uniqueName]
        public string? lName { get; set; }
        [RegularExpression("(cairo|benha)")]
        public string? address { get; set; }
        public char Sex { get; set; }
        public DateOnly BDate { get; set; }
        [Required]
        [Remote("CheckSalary","employee",ErrorMessage = "salary must be between 10000 and 20000")]
        public int salary { get; set; }
        [ForeignKey("employee_super")]
        public int? supeerSSN { get; set; }
        [ForeignKey("department")]
        public int? DNO { get; set; }
        #region self
        [InverseProperty("employee_super")]
        public virtual List<employee>? Employees { get; set; }
        public employee? employee_super { get; set; }
        #endregion
        #region department
        public department? department { get; set; }
        public virtual List<department>? Departments { get; set; }
        #endregion
        public virtual List<works_on>? won { get; set; }
        public virtual List<dependent>? dependents { get; set; }
    }
}
