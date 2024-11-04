using SWP_Project.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SWP_Project.Data;
namespace SWP_Project.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; } // Liên kết với bảng người dùng

        [ForeignKey("Event")]
        public int EventId { get; set; } // Liên kết với sự kiện

        public decimal Price { get; set; } // Giá vé
        public int Quantity { get; set; } // Số lượng vé
        public int SeatNumber { get; set; } // Add this field for seat number
        public string PaymentMethod { get; set; } // Add this field for payment method

        public bool IsTransferred { get; set; } // Trạng thái chuyển nhượng
        public bool IsCancelled { get; set; } // Trạng thái hủyần 

        // Điều hướng (Navigation Properties)
        public virtual User User { get; set; } // Nếu có bảng người dùng
        public virtual Event Event { get; set; } // Liên kết với bảng sự kiện
    }
}