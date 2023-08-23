using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystemWeb.Models
{
    public class School
    {
        public int SchoolId { get; set; }

        [Required(ErrorMessage = "School Name is required.")]
        [StringLength(100, ErrorMessage = "School Name must not exceed 100 characters.")]
        [Display(Name = "School Name")]
        public string SchoolName { get; set; }

        [StringLength(200, ErrorMessage = "School Description must not exceed 200 characters.")]
        [Display(Name = "School Description")]
        public string SchoolDescription { get; set; }

        [ForeignKey("Address")]
        [Display(Name = "Address")]
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
    }

}
