using System.ComponentModel.DataAnnotations;

namespace SchoolSystemWeb.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }

        [Required(ErrorMessage = "Subject Name is required.")]
        [StringLength(50, ErrorMessage = "Subject Name must not exceed 50 characters.")]
        [Display(Name = "Subject Name")]
        public string SubjectName { get; set; }
    }

}
