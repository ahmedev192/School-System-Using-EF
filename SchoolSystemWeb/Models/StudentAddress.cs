using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystemWeb.Models
{
    public class StudentAddress
    {

        [ForeignKey("Student")]
        [Display(Name = "Student")]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        [ForeignKey("Address")]
        [Display(Name = "Address")]
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }

        [Required(ErrorMessage = "Date From is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Date From")]
        public DateTime DateFrom { get; set; }

        [Required(ErrorMessage = "Date To is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Date To")]
        public DateTime DateTo { get; set; }

        [StringLength(200, ErrorMessage = "Address Details must not exceed 200 characters.")]
        [Display(Name = "Address Details")]
        public string AddressDetails { get; set; }
    }

}
