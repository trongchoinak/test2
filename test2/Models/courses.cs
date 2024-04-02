namespace test2.Models
{
    public class courses
    {
        public string courseid { get; set; }
        public string coursename { get; set; }
        public string description { get; set;}

        public ICollection<studentcourseid> studentcourseids { get; set; }
    }
}
