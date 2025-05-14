using System.ComponentModel.DataAnnotations;

namespace FinancePreferenceSys.Models
{
    public class RegisterViewModel
    {
        [Required, Display(Name = "使用者名稱")]
        public string UserName { get; set; }

        [Required, EmailAddress, Display(Name = "電子郵件")]
        public string Email { get; set; }

        [Required, Display(Name = "扣款帳號")]
        public string Account { get; set; }

        [Required, DataType(DataType.Password), Display(Name = "密碼")]
        public string Password { get; set; }

        [Required, DataType(DataType.Password), Display(Name = "確認密碼"), Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
