using System.ComponentModel.DataAnnotations;

namespace FinancePreferenceSys.Models
{
    public class LoginViewModel
    {
        [Required, EmailAddress, Display(Name = "電子郵件")]
        public string Email { get; set; }

        [Required, DataType(DataType.Password), Display(Name = "密碼")]
        public string Password { get; set; }
    }
}
