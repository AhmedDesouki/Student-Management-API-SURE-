using StudentManagementSys_SURE.Models;
using StudentManagementSys_SURE.Repository;

namespace StudentManagementSys_SURE.UnitOfWork
{
    public class UnitWork
    {
        StudentManagContext db;
        GenericRepository<Department> generic_dept_Reps;
        GenericRepository<Student> generic_Std_Reps;
        StudentRepository studentRepository;
        public UnitWork(StudentManagContext db)
        {
            this.db = db;
        }
        public GenericRepository<Student> genericStdReps
        {
            get
            {
                if(generic_Std_Reps == null)
                {
                    generic_Std_Reps = new GenericRepository<Student>(db);
                }
                return generic_Std_Reps;
            }
        }

        public GenericRepository<Department> genericDeptReps
        {
            get
            {
                if(generic_dept_Reps== null)
                {
                    generic_dept_Reps = new GenericRepository<Department>(db);
                }
                return generic_dept_Reps;
            }
        }
        public StudentRepository StudentRepository
        { 
            get 
            {
               if(studentRepository == null)
                {
                    studentRepository = new StudentRepository(db);  
                }
               return studentRepository;
            } 
        
        }   
        
        public void Save()
        {
            db.SaveChanges();
        }


    }
}
