using Microsoft.EntityFrameworkCore;
using StudentManagementSys_SURE.Models;

namespace StudentManagementSys_SURE.Repository
{
    public class StudentRepository
    {
        StudentManagContext db;

       public StudentRepository(StudentManagContext db)
        {
            this.db = db;
        }
        //public List<Student> selectAll()
        //{
        //    return db.Students.ToList();
        //}

        public Student GetById(int id) { 
            return db.Students.Include(s => s.Department)
                      .FirstOrDefault(s => s.Id == id);
        }

        public Student GetByName(string name) { 
        
            return db.Students
                      .Include(s => s.Department)
                      .FirstOrDefault(s => s.Name == name);

        }

    }
}
