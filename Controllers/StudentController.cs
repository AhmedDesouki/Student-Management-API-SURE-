using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementSys_SURE.DTO;
using StudentManagementSys_SURE.Models;
using StudentManagementSys_SURE.Repository;
using StudentManagementSys_SURE.UnitOfWork;

namespace StudentManagementSys_SURE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        //StudentRepository reps;
        //GenericRepository<Student> genericReps;
        ////public StudentController(StudentRepository reps)
        ////{
        ////    this.reps=reps;
        ////}

        //public StudentController(GenericRepository<Student> genericReps, StudentRepository reps)
        //{
        //    this.genericReps = genericReps;
        //    this.reps = reps;
        //}

        UnitWork unit;

        public StudentController(UnitWork unit) 
        {
            this.unit = unit;
        }


        [HttpGet]
        public IActionResult getAll()
        {
            List<Student> students = unit.genericStdReps.selectAll();
            List<StudentDTO> studentDTOs = new List<StudentDTO>();

            foreach (Student student in students)
            {
                StudentDTO studentDTO = new StudentDTO();
                {
                    studentDTO.Id = student.Id;
                    studentDTO.Name = student.Name;
                    studentDTO.Address = student.Address;
                    studentDTO.Age = student.Age;
                    studentDTO.DeptName = student?.Department?.Name;

                };
                studentDTOs.Add(studentDTO);    
            }

            return Ok(studentDTOs);
        }
        // [HttpGet("{id}")]
        [HttpGet("{id:int}")]
        public IActionResult GetStudentById(int id)
        {

            // use eager loading 
            Student student = unit.StudentRepository.GetById(id);
            if (student == null) { return NotFound(); }
            else {

                StudentDTO studentDTO = new StudentDTO();
                {
                    studentDTO.Id = student.Id;
                    studentDTO.Name = student.Name;
                    studentDTO.Address = student.Address;
                    studentDTO.Age = student.Age;
                    studentDTO.DeptName = student.Department.Name;

                };

                return Ok(studentDTO);
            }
        }


        [HttpGet("{name}")]
        public IActionResult GetStudentByName(string name)
        {

            // use eager loading 
            Student student = unit.StudentRepository.GetByName(name);
            if (student == null) { return NotFound(); }
            else
            {

                StudentDTO studentDTO = new StudentDTO();
                {
                    studentDTO.Id = student.Id;
                    studentDTO.Name = student.Name;
                    studentDTO.Address = student.Address;
                    studentDTO.Age = student.Age;
                    studentDTO.DeptName = student.Department.Name;

                };

                return Ok(studentDTO);
            }
        }



        [HttpPost]
        public IActionResult AddStudent(Student student) {
            if(student == null) { return BadRequest(); }
            if(!ModelState.IsValid) { return BadRequest(); }
            unit.genericStdReps.Add(student);
            unit.Save();

            return CreatedAtAction("GetStudentById", new {id=student.Id},student);
        }

       
        [HttpPut("{id}")]
        public IActionResult EditStudent(Student student,int id) {
         
            if(student == null) { return BadRequest();}
            if(!ModelState.IsValid) { return BadRequest(); }
            if(student.Id != id) { return BadRequest(); }

            unit.genericStdReps.Update(student);
            unit.Save();
            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id) {
            Student student = unit.StudentRepository.GetById(id);  
            if(student == null) { return NotFound();}
            unit.genericStdReps.Delete(id);
            unit.Save();
            return Ok(student);

        }

    }
}
