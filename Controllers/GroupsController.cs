using Lesson_2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lesson_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly AppDbContext _db;

        public GroupsController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetAllGroups()
        {
            var groups = _db.Groups.ToList();
            return Ok(groups);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetGroupById([FromRoute] int id)
        {
            if (id <= 0) return BadRequest("Некорректный id"); //400
            var group = _db.Groups.FirstOrDefault(g => g.Id == id);
            if (group is null)
                return NotFound();

            return Ok(group);
        }

        [HttpPost]
        public IActionResult CreateGroup([FromBody] Group group)
        {
            // Проверка на уникальность названия группы
            var nameExists = _db.Groups.Where(g => g.Name == group.Name).ToList();
            if (nameExists.Any())
                return Conflict("Группа с таким названием уже существует");

            _db.Groups.Add(group);
            _db.SaveChanges();
            return Created();
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateGroup([FromBody] Group group, [FromRoute] int id)
        {
            if (id != group.Id)
                return BadRequest("id в пути и в теле запроса не совпадает");

            if (id <= 0)
                return BadRequest("Некорректный id");

            var exists = _db.Groups.Any(g => g.Id == id);
            if (!exists)
                return NotFound();

            // Проверка на уникальность названия группы (исключая текущую группу)
            var nameExists = _db.Groups.FirstOrDefault(g => g.Name == group.Name && g.Id != id);
            if (nameExists is not null)
                return Conflict("Группа с таким названием уже существует");

            _db.Groups.Update(group);
            _db.SaveChanges();

            return NoContent(); //204
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteGroup([FromRoute] int id)
        {
            var group = _db.Groups.Find(id);
            if (group is null)
                return NotFound();

            _db.Groups.Remove(group);
            _db.SaveChanges();

            return NoContent(); //204
        }
    }
}