using Microsoft.AspNetCore.Mvc;
using test2.Models;
using test2.Services;

namespace REST_API_TEMPLATE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ICoursesServices _coursesService;

        public StudentController(ICoursesServices coursesService)
        {
            _coursesService = coursesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudent(string fullName = null, int page = 1, int pageSize = 10)
        {
            // Lấy danh sách sinh viên từ dịch vụ hoặc repository của bạn
            var students = await _coursesService.getAllStudent();

            if (students == null || students.Count == 0)
            {
                return StatusCode(StatusCodes.Status204NoContent, "Không có sinh viên trong cơ sở dữ liệu");
            }

            // Áp dụng bộ lọc nếu có
            if (!string.IsNullOrEmpty(fullName))
            {
                students = students.Where(s => s.name.Contains(fullName)).ToList();
            }
            int totalRecords = students.Count;
            var paginatedStudents = students.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            // Tạo đối tượng phản hồi phân trang
            var response = new
            {
                TotalRecords = totalRecords,
                PageSize = pageSize,
                CurrentPage = page,
                Students = paginatedStudents
            };

            return StatusCode(StatusCodes.Status200OK, response);
        }


        [HttpGet("id")]
        public async Task<IActionResult> GetIdStudent(Guid id, bool includeCourses = false)
        {
            student student = await _coursesService.GetIdStudent(id, includeCourses);

            if (student == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No Author found for id: {id}");
            }

            return StatusCode(StatusCodes.Status200OK, student);
        }

        [HttpPost]
        public async Task<ActionResult<courses>> AddStudent(student student)
        {
            var dbCourses = await _coursesService.AddStudent(student);

            if (dbCourses == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{student.name} could not be added.");
            }

            return CreatedAtAction("GetIdStudent", new { id = student.id }, student);
        }
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            var courses = await _coursesService.GetIdStudent(id, false);
            (bool status, string message) = await _coursesService.DeleteStudent(courses);

            if (status == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return StatusCode(StatusCodes.Status200OK, courses);
        }
    }
}