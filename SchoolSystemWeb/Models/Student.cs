using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SchoolSystemWeb.Models
{

    public class Student : Human
    {
        public int StudentId { get; set; }

        [Range(0.0, 4.0, ErrorMessage = "GPA must be between 0 and 4.")]
        public float GPA { get; set; }


    }
}
