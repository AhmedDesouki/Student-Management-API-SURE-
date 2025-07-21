using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementSys_SURE.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }
        [ForeignKey("DepartmentId")]
        public int? DepartmentId { get; set; }
        
        public Department? Department { get; set; }
    }
}
