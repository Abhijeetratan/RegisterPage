using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace RegisterPage.Models
{
    public class Reg
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Student Name")]
        [Required(ErrorMessage = "Please enter the first name.")]
        public string First_Name { get; set; }

        [Display(Name = "Last Name")]
        public string Last_Name { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a password.")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; }
    }
}
