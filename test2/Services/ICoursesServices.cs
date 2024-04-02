using test2.Models;

namespace test2.Services
{
    public interface ICoursesServices
    {
        Task<List<courses>> GetAllCourses();
        Task<courses> GetIdCourses(Guid id, bool includeCourses = false);
        Task<courses> AddCourses(courses courses);
        Task<courses> UpdateCourses(courses courses);
        Task<(bool, string)> DeleteCourses(courses courses);
        //Học Sinh
        Task<List<student>> getAllStudent();
        Task<student> GetIdStudent(Guid id, bool includeCourses = false);
        Task<student> AddStudent(student student);
        Task<student> UpdateStudent(student student);
        Task<(bool, string)> DeleteStudent(student student);
        
        Task<List<Models.studentcourseid>> GetAllSCourses();
        Task<Models.studentcourseid> GetIdSCourses(Guid id);
        Task<Models.studentcourseid> AddSCourses(Models.studentcourseid sc);
        Task<Models.studentcourseid> UpdateSCourses(Models.studentcourseid sc);
        Task<(bool, string)> DeleteSCourses(Models.studentcourseid sc);
    }
}
