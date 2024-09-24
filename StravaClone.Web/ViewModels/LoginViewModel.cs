using System.ComponentModel.DataAnnotations;

namespace StravaClone.Web.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Email Address")]
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
