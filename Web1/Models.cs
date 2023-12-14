
using System.ComponentModel.DataAnnotations;

namespace Web1.Models
{
    public class ContactUs
    {
        [Required(ErrorMessage = "Please Enter Your Firts Name.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please Enter Your Last Name.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please Enter Your Phone.")]
        public string Phone { get; set; }

        public string? Mobile { get; set; }

        [Required(ErrorMessage = "Please Select Reason For Contact.")]
        public string ReasonForContact { get; set; }

        public string? CompanyName { get; set; }

        [Required(ErrorMessage = "Please Enter Your Email Address.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }

        public string? Comment { get; set; }
    }
}
