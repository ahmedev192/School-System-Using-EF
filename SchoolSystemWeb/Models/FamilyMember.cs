using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystemWeb.Models
{
    public class FamilyMember
    {
        public int FamilyMemberId { get; set; }
        [ForeignKey("Family")]
        public int FamilyId { get; set; }
        public virtual Family Family { get; set; }
        [ForeignKey("Parent")]
        public int ParentId { get; set; }
        public virtual Parent parent { get; set; }
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}
