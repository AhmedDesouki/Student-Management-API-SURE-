using Microsoft.AspNetCore.Mvc;
using StudentManagementSys_SURE.Models;
using StudentManagementSys_SURE.Repository;
using StudentManagementSys_SURE.UnitOfWork;

namespace StudentManagementSys_SURE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {


        //GenericRepository<Department> genericReps;

        //public DepartmentController(GenericRepository<Department> genericReps)
        //{
        //    this.genericReps = genericReps;

        //}

        UnitWork unit;

        public DepartmentController(UnitWork unit)
        {
            this.unit = unit;
        }

        [HttpPost]
        public IActionResult AddDepartment(Department department)
        {
            if (department == null) { return BadRequest(); }
            if (!ModelState.IsValid) { return BadRequest(); }
            unit.genericDeptReps.Add(department);
            unit.Save();

            return Ok(department);
        }


    }
}
