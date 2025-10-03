using Lesson_2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lesson_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _db;

        public StudentsController(AppDbContext db) 
        {
            _db = db;
        }


        [HttpGet]
        public IActionResult GetAllSrudents()
        {   
            var students = _db.Students.ToList();
            return Ok("Список студентов");
        }

        [HttpGet("{id:int}")]
        public IActionResult GetStudentById([FromRoute] int id) 
        {
            if (id <= 0) return BadRequest("Некорректный id"); //400
            var student = _db.Students.FirstOrDefault(s => s.Id == id);
            if (student is null)
                return NotFound();

            return Ok(student);
        }

        [HttpPost]
        public IActionResult GetStudentBy([FromBody] Student student)
        {
            var emailExists = _db.Students.Where(s => s.User.Email == student.User.Email).ToList();
            if (emailExists.Any())
                return Conflict("Такой email уже используется");

            _db.Students.Add(student);
            _db.SaveChanges();
            return Created();
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateStudent([FromBody] Student student, [FromRoute] int id)
        {
            if (id != student.Id)
                return BadRequest("id в пути и в теле запроса не совпадает");

            if (id <= 0)
                return BadRequest("Некорректный id");

            var exists = _db.Students.Any(s => s.Id == id);
            if (!exists)
                return NotFound();

            var emailExists = _db.Students.FirstOrDefault(s => s.User.Email == student.User.Email && s.Id != id);
            if (emailExists is not null)
                return Conflict("Такой email уже используется");

            _db.Students.Update(student);
            _db.SaveChanges();

            return NoContent(); //204
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteStudent([FromRoute] int id) 
        {
            var student = _db.Students.Find(id);
            if (student is null)
                return NotFound();
            _db.Students.Remove(student);
            _db.SaveChanges();
            //Delete

            return NoContent(); //204
        }
    }
}
