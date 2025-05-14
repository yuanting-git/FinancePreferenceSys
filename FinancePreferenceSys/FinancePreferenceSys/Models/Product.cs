using System.ComponentModel.DataAnnotations;

namespace FinancePreferenceSys.Models
{
    public class Product
    {
        [Key]
        public int No { get; set; }  // 主鍵（產品流水號）

        [Required]
        public string ProductName { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public decimal FeeRate { get; set; }  // 百分比，如 0.1 表示 10%
    }
}
