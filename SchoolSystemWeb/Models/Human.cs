using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SchoolSystemWeb.Models
{
    public enum Gender
    {
        Male,
        Female,
        Other,
        Unknown
    }
    public abstract class Human
    {
        [Display(Name = "Gender")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(50, ErrorMessage = "First Name must not exceed 50 characters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(50, ErrorMessage = "Middle Name must not exceed 50 characters.")]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(50, ErrorMessage = "Last Name must not exceed 50 characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Date of Birth is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Age")]
        public int Age => CalculateAge(DateOfBirth);

        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Invalid Phone Number.")]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [StringLength(20, ErrorMessage = "Social Security Number must not exceed 20 characters.")]
        [Display(Name = "Social Security Number")]
        public string SocialSecurityNumber { get; set; }
        private int CalculateAge(DateTime dateOfBirth)
        {
            DateTime currentDate = DateTime.Now.Date;
            DateTime birthDate = dateOfBirth;
            int age = currentDate.Year - birthDate.Year;

            if (currentDate.Month < birthDate.Month ||
                (currentDate.Month == birthDate.Month && currentDate.Day < birthDate.Day))
            {
                age--;
            }

            return age;
        }
    }

}
