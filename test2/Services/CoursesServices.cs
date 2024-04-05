using Microsoft.EntityFrameworkCore;
using test2.Models;
using test2.Data;
using System;
using test2.Services;

namespace WebAPI.Services
{
    public class CoursesServices : ICoursesServices
    {
        private readonly test2Dbcontext _context;
        private ICoursesServices _coursesServicesImplementation;
        public CoursesServices(test2Dbcontext context) { _context = context; }

        #region Courses

        public async Task<List<courses>> GetAllCourses()
        {
            try
            {
                return await _context.courses.ToListAsync();
            }
            catch (Exception e)
            {
                return null;
            }
        }
        
        public async Task<courses> GetIdCourses(Guid id, bool includeCourses)
        {
            try
            {
                if (includeCourses)
                {
                    return await _context.courses.Include(c => c.studentcourseids).FirstOrDefaultAsync(i => i.courseid.Equals(id));
                }

                return await _context.courses.FindAsync(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<courses> AddCourses(courses courses)
        {
            try
            {
                await _context.courses.AddAsync(courses);
                await _context.SaveChangesAsync();
                return await _context.courses.FindAsync(courses.courseid);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<courses> UpdateCourses(courses courses)
        {
            try
            {
                _context.Entry(courses).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return courses;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<(bool, string)> DeleteCourses(courses courses)
        {
            try
            {
                var dbCourses = await _context.courses.FindAsync(courses.courseid);
                if (dbCourses == null)
                {
                    return (false, "Not Found");
                }

                _context.courses.Remove(courses);
                return (true, "Success");
            }
            catch (Exception e)
            {
                return (false, "Failed");
            }
        }

        public Task<List<student>> getAllStudent()
        {
            return _coursesServicesImplementation.getAllStudent();
        }

        #endregion

        #region Student

        public async Task<List<student>> GetAllStudent()
        {
            try
            {
                return await _context.students.ToListAsync();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<student> GetIdStudent(Guid id, bool includeCourses)
        {
            try
            {
                if (includeCourses)
                {
                    return await _context.students .Include(c => c.studentcourseids).FirstOrDefaultAsync(i => i.id.Equals(id));
                    ;
                }

                return await _context.students.FindAsync(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<student> AddStudent(student student)
        {
            try
            {
                await _context.students.AddAsync(student);
                await _context.SaveChangesAsync();
                return await _context.students.FindAsync(student.id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<student> UpdateStudent(student student)
        {
            try
            {
                _context.Entry(student).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return student;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<(bool, string)> DeleteStudent(student student)
        {
            try
            {
                var dbStudent = await _context.students.FindAsync(student);
                if (dbStudent == null)
                {
                    return (false, "Courses could not be found");
                }

                _context.students.Remove(student);
                await _context.SaveChangesAsync();
                return (true, "Amzing good job you");
            }
            catch (Exception e)
            {
                return (false, e.Message);
            }
        }

        #endregion

        #region StudentCourese

        public async Task<List<studentcourseid>> GetAllSCourses()
        {
            try
            {
                return await _context.studentcourseids.ToListAsync();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<studentcourseid> GetIdSCourses(Guid id)
        {
            try
            {
                return await _context.studentcourseids.FindAsync(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<studentcourseid> AddSCourses(studentcourseid sc)
        {
            try
            {
                await _context.studentcourseids.AddAsync(sc);
                await _context.SaveChangesAsync();

                return await _context.studentcourseids.FindAsync(sc.courseid);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<studentcourseid> UpdateSCourses(studentcourseid sc)
        {
            try
            {
                _context.Entry(sc).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return sc;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<(bool, string)> DeleteSCourses(studentcourseid sc)
        {
            try
            {
                var dbSC = await _context.studentcourseids.FindAsync(sc.courseid);
                if (dbSC == null)
                {
                    return (false, "Courses could not be found");
                }
                _context.studentcourseids.Remove(sc);
                await _context.SaveChangesAsync();
                return (true, "Amazing good job you");
            }
            catch (Exception e)
            {
                return (false, e.Message);
            }
        }
        #endregion
    }
}