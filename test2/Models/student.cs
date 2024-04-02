namespace test2.Models
{
    public class student
    {
        public string id { get; set; }
        public string name { get; set; }
        public ICollection<studentcourseid> studentcourseids { get; set; }
    }
}
