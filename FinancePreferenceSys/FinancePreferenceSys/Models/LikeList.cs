using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinancePreferenceSys.Models
{
    public class LikeList
    {
        public int SN { get; set; }
        public int OrderNum { get; set; }
        public string Account { get; set; }
        public decimal TotalFee { get; set; }
        public decimal TotalAmount { get; set; }
        public int ProductNo { get; set; }
        public Guid UserID { get; set; }
        public string? ProductName { get; set; }
        public string? UserEmail { get; set; }
    }
}
