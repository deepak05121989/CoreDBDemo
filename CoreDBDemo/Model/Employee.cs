using System.ComponentModel.DataAnnotations;

namespace CoreDBDemo.Model
{
    public class Employee
    {
        [Key]
        public  int? EmployeeId { get; set; }
        [Required]
        public string? EmployeeName { get; set; }
        [Required]
        public string? EmployeeEmail { get; set; }
        [Required]
        public double? EmployeeSalary { get; set; }
        [Required]
        public long? EmployeeMobile { get; set; }
    }
}
