using System.ComponentModel.DataAnnotations;
using System.Web;

namespace BankSystem_v2.Models
{
    public class UserView
    {
        public string UserId { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "The field {0} is required")]
        [Display(Name = "E-mail")]
        [StringLength(100, ErrorMessage = "The field {0} can contain maximum {1} and  minimum {2} character", MinimumLength = 7)]
        public string userName { get; set; }

        [StringLength(50, ErrorMessage = "The field {0} can contain maximum {1} and  minimum {2} character", MinimumLength = 2)]
        [Required(ErrorMessage = "The field {0} is required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(50, ErrorMessage = "The field {0} can contain maximum {1} and  minimum {2} character", MinimumLength = 2)]
        [Required(ErrorMessage = "The field {0} is required")]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [StringLength(50, ErrorMessage = "The field {0} can contain maximum {1} and  minimum {2} character", MinimumLength = 2)]
        [Required(ErrorMessage = "The field {0} is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
   
        [StringLength(20, ErrorMessage = "The field {0} can contain maximun {1} and  minimun {2} character", MinimumLength = 10)]
        [Required(ErrorMessage = "The field {0} is required")]
        public string Address { get; set; }

        public HttpPostedFileBase Photo { get; set; }
    }
}