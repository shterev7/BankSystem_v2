using DataAccess.Entity;
using System.ComponentModel.DataAnnotations;

namespace BankSystem_v2.Models
{
    public class UserIndexView : User
     {

        [Display(Name = "Is Admin?")]
        public bool IsAdmin { get; set; }
     }
    
}