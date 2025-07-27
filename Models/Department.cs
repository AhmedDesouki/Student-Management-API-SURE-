namespace StudentManagementSys_SURE.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ManagerName { get; set; }

        public List<Student> students { get; set; }=new List<Student>();


    }
}
