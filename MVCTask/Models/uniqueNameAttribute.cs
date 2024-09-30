using System.ComponentModel.DataAnnotations;

namespace MVCTask.Models
{
    public class uniqueNameAttribute: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return null;
            }

            // check in database

            string newName=value.ToString();
            iticontext context=new iticontext();
        employee emp=context.Employees.SingleOrDefault(s=>s.fName==newName);
            if(emp!=null)
            {
                return new ValidationResult("this name already exist");

            }
            return ValidationResult.Success;
            return base.IsValid(value, validationContext);
        }
    }
}
