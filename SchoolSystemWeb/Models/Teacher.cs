using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystemWeb.Models
{
    public class Teacher : Human
    {
        public int TeacherId { get; set; }

        [ForeignKey("School")]
        [Display(Name = "School")]
        public int SchoolId { get; set; }
        public virtual School School { get; set; }

        [StringLength(200, ErrorMessage = "About must not exceed 200 characters.")]
        public string About { get; set; }
    }

}
