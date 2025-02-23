using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Grade
    {
        [Key]
        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public string GradeDescription { get; set;}
        public DateTime Created_Date { get; set; }
        public DateTime Modified_Date { get;set; }
        public sbyte Created_By { get; set; }
        public sbyte ModifiedBy { get;set; }

        public ICollection<EmployeeClass> Employees { get; set; } = new List<EmployeeClass>();


    }


}
