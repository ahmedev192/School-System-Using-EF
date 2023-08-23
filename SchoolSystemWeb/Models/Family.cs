using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystemWeb.Models
{
    public class Family
    {
        public int FamilyId { get; set; }
        [Required(ErrorMessage = "Family Name is required.")]
        [StringLength(40, ErrorMessage = "Family Name must not exceed 40 characters.")]
        [Display(Name = "Family Name")]
        public string FamilyName { get; set; }
        [ForeignKey("Parent")]
        public int ParentId { get; set; }
        public virtual Parent Parent { get; set; }
    }
}
