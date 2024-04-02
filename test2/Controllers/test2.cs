using Microsoft.AspNetCore.Mvc;
using test2.Models;
using test2.Services;

namespace test2.Controllers
{
    public class test2 : Controller
    {
        [ApiController]
        [Route("api/[controller]")]
        public class AuthorController : ControllerBase
        {
            private readonly ICoursesServices _coursesService;

            public AuthorController(ICoursesServices coursesService)
            {
                _coursesService = coursesService;
            }

            [HttpGet]
            public async Task<IActionResult> GetCourses()
            {
                var authors = await _coursesService.GetAllCourses();

                if (authors == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, "No authors in database");
                }

                return StatusCode(StatusCodes.Status200OK, authors);
            }

            [HttpGet("id")]
            public async Task<IActionResult> GetCourses(Guid id, bool includeCourses = false)
            {
                courses courses = await _coursesService.GetIdCourses(id, includeCourses);

                if (courses == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, $"No Author found for id: {id}");
                }

                return StatusCode(StatusCodes.Status200OK, courses);
            }

            [HttpPost]
            public async Task<ActionResult<courses>> AddCourses(courses courses)
            {
                var dbCourses = await _coursesService.AddCourses(courses);

                if (dbCourses == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"{courses.coursename} could not be added.");
                }

                return CreatedAtAction("GetCourses", new { id = courses.courseid }, courses);
            }

            [HttpPut("id")]
            public async Task<IActionResult> UpdateCourses(Guid id, courses courses)
            {
                if (id != Guid.Parse(courses.courseid))
                {
                    return BadRequest();
                }

                courses dbCourses = await _coursesService.UpdateCourses(courses);

                if (dbCourses == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"{courses.coursename} could not be updated");
                }

                return NoContent();
            }


            [HttpDelete("id")]
            public async Task<IActionResult> DeleteCourse(Guid id)
            {
                var courses = await _coursesService.GetIdCourses(id, false);
                (bool status, string message) = await _coursesService.DeleteCourses(courses);

                if (status == false)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, message);
                }

                return StatusCode(StatusCodes.Status200OK, courses);
            }
        }
    }
}
