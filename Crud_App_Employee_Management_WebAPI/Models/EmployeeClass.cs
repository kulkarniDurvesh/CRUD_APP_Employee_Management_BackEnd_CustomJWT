using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class EmployeeClass
    {
        [Key]
        public int EmployeeId { get; set; }
        public string? EmployeeFirstName { get; set; }
        public string? EmployeeLastName { get; set; }
        public string? EmployeeDesignation {  get; set; }

        public string? EmployeeUserName {  get; set; }

        public string? EmployeePassword { get; set; }
        public int EmployeeAge { get; set; }

        public string? EmployeeCity { get; set;}
        public string? EmployeeState { get; set; }

        public string? EmployeeZipCode { get; set;}
        public string? EmployeeCountry { get; set; }
        public string? EmployeePhone { get; set;}

        public int EmployeeGrade { get; set; }

        public Grade Grade { get; set; }


    }
}
