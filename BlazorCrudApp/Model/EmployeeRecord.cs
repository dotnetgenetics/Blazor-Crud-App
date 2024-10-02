using System.ComponentModel.DataAnnotations;

namespace BlazorCrudApp.Model
{
    public class EmployeeRecord
    {
        public int EmployeeId { get; set; }

        [Display(Name = "Government ID")]
        [Required(ErrorMessage = "Government ID is required")]
        public string EmployeeGovtId { get; set; }

        [Display(Name = "Employee Name")]
        [Required(ErrorMessage = "Name is required")]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter integer number")]
        public int? Age { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required]
        [Range(1000, 99999.99, ErrorMessage = "Please enter value from 1000 to 99999.99")]
        public decimal? Salary { get; set; }

        [Required(ErrorMessage = "Designation is required")]
        [MinLength(2, ErrorMessage = "Min length of designation is 2 characters")]
        public string Designation { get; set; }

        [Display(Name = "Has Dependents")]
        public bool HasDependents { get; set; } = false;

        public string DisplayForDependents
        {
            get
            {
                if (HasDependents)
                    return "Yes";

                return "No";
            }
        }

        public EmployeeRecord()
        {
            EmployeeId = 0;
            Address = string.Empty;
            Salary = 0;
            Age = 0;
            Address = string.Empty;
            EmployeeName = string.Empty;
            Designation = string.Empty;
            EmployeeGovtId = string.Empty;
            HasDependents = false;
        }
    }
}
