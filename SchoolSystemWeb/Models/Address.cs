using System.ComponentModel.DataAnnotations;

namespace SchoolSystemWeb.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        [Required(ErrorMessage = "City is required.")]
        [StringLength(40, ErrorMessage = "City must not exceed 40 characters.")]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        [StringLength(40, ErrorMessage = "Country must not exceed 40 characters.")]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [StringLength(40, ErrorMessage = "Region must not exceed 40 characters.")]
        [Display(Name = "Region")]
        public string Region { get; set; }

        [Required(ErrorMessage = "Postal Code is required.")]
        [StringLength(5, ErrorMessage = "Postal Code must not exceed 5 characters.")]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Street Name is required.")]
        [StringLength(40, ErrorMessage = "Street Name must not exceed 40 characters.")]
        [Display(Name = "Street Name")]
        public string StreetName { get; set; }
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }


    }
}
