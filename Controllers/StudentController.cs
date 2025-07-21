using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementSys_SURE.DTO;
using StudentManagementSys_SURE.Models;

namespace StudentManagementSys_SURE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        StudentManagContext db;

        public StudentController(StudentManagContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public List<Student> getall()
        {
            return db.Students.ToList();
        }
        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
           
            // use eager loading 
            Student student = db.Students
                      .Include(s => s.Department)
                      .FirstOrDefault(s => s.Id == id);
            if (student == null) { return NotFound();}
            else {
            
                StudentDTO studentDTO = new StudentDTO();
                {
                    studentDTO.Id= student.Id;
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
            db.Students.Add(student);
            db.SaveChanges();

            return CreatedAtAction("GetStudentById", new {id=student.Id},student);
        }

       
        [HttpPut("{id}")]
        public IActionResult EditStudent(Student student,int id) {
         
            if(student == null) { return BadRequest();}
            if(!ModelState.IsValid) { return BadRequest(); }
            if(student.Id != id) { return BadRequest(); }

            db.Students.Update(student);
            db.SaveChanges();
            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id) { 
        Student student=db.Students.Find(id);  
            if(student == null) { return NotFound();}
            db.Students.Remove(student);
            db.SaveChanges();
            return Ok(student);

        }

    }
}
