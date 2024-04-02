namespace test2.Models
{
    public class studentcourseid
    {
        public string id { get; set; }
        public string courseid { get; set; }
        public student student { get; set; }
        public courses courses { get; set; }
    }
}
