using System.ComponentModel.DataAnnotations;

namespace test2.Models
{
    public class student
    {
        public string id { get; set; }
        public string name { get; set; }
        [Required]
        [StringLength(maximumLength:50,MinimumLength =10,ErrorMessage ="độ dài từ 10 đến 50")]
        public ICollection<studentcourseid> studentcourseids { get; set; }
    }
}
