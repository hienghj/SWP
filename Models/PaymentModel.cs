namespace SWP_Project.Models
{
    public class PaymentModel
    {
        // Thuộc tính để lưu trữ phương thức thanh toán đã chọn (thẻ tín dụng, PayPal, ví điện tử, v.v.)
        public string SelectedPaymentMethod { get; set; }

        // Các thuộc tính dành riêng cho phương thức thanh toán bằng thẻ tín dụng
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public string ExpirationDate { get; set; }
        public string CVV { get; set; }

        // Các thuộc tính dành cho các phương thức thanh toán khác nếu cần thiết
        public string PayPalAccount { get; set; } // PayPal
        public string EWalletProvider { get; set; } // Ví điện tử

        // Các thuộc tính bổ sung có thể tùy chọn
        public decimal? Amount { get; set; } // Số tiền thanh toán
        public string TransactionId { get; set; } // Mã giao dịch sau khi thanh toán
    }
}
