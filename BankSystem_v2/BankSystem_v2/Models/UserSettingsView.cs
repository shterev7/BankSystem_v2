using DataAccess.Entity;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace BankSystem_v2.Models
{
    
    public class UserSettingsView  : User  
    {
        [Display(Name = "New Photo")]
        public HttpPostedFile NewPhoto { get; set; }
    }
}