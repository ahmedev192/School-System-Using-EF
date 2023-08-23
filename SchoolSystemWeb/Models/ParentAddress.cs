using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystemWeb.Models
{
    public class ParentAddress
    {


        [ForeignKey("Parent")]
        [Display(Name = "Parent")]
        public int ParentId { get; set; }
        public virtual Parent Parent { get; set; }

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
    }

}
