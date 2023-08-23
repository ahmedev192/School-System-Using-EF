using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystemWeb.Models
{
    public class Homework
    {
        public int HomeworkId { get; set; }
        [ForeignKey("Student")]
        [Display(Name = "Student")]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        [Required(ErrorMessage = "Creation Date is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Creation Date")]
        public DateTime CreationDate { get; set; }

        [Required(ErrorMessage = "Deadline is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Deadline")]
        public DateTime DeadLine { get; set; }

        [Required(ErrorMessage = "Homework Content is required.")]
        [Display(Name = "Homework Content")]
        public string HomeworkContent { get; set; }

        [Range(0.0, 100.0, ErrorMessage = "Grade must be between 0 and 100.")]
        public float Grade { get; set; }

        [Display(Name = "Comment")]
        public string Comment { get; set; }

    }
}
