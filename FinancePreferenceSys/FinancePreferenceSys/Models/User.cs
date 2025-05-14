using System.ComponentModel.DataAnnotations;

namespace FinancePreferenceSys.Models
{
    public class User
    {
        [Key]
        public string UserID { get; set; }  // 主鍵

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Account { get; set; }

        [Required]
        public string PasswordHash { get; set; } // 密碼雜湊值

        public DateTime ModDate { get; set; } // 密碼雜湊值
    }
}
