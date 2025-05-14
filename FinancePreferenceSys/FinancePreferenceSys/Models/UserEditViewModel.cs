using System.ComponentModel.DataAnnotations;

namespace FinancePreferenceSys.Models
{
    public class UserEditViewModel
    {
        [Required]
        public string UserID { get; set; }

        [Required(ErrorMessage = "使用者名稱為必填")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "扣款帳號為必填")]
        public string Account { get; set; }

        public string? Password { get; set; } // 可空，不強制
    }
}
