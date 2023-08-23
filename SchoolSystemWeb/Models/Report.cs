using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystemWeb.Models
{
    public class Report
    {
        public int ReportId { get; set; }

        [ForeignKey("Student")]
        [Display(Name = "Student")]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        [Required(ErrorMessage = "Creation Date is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Creation Date")]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Report Comment")]
        public string ReportComment { get; set; }

        [Display(Name = "About Teacher's Comment")]
        public string AboutTeachersComment { get; set; }

        [Display(Name = "Any Other Notes")]
        public string AnyOtherNotes { get; set; }
    }

}
