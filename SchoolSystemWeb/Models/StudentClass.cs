using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystemWeb.Models
{
    public class StudentClass
    {

        [ForeignKey("Student")]
        [Display(Name = "Student")]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        [ForeignKey("Class")]
        [Display(Name = "Class")]
        public int ClassId { get; set; }
        public virtual Class Class { get; set; }

        [Required(ErrorMessage = "Date From is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Date From")]
        public DateTime DateFrom { get; set; }

        [Required(ErrorMessage = "Date To is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Date To")]
        public DateTime DateTo { get; set; }
    }

    // Other classes...
}
