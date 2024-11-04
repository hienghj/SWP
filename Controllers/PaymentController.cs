using Microsoft.AspNetCore.Mvc;
using SWP_Project.Models;

public class PaymentController : Controller
{
    // Hiển thị trang chọn phương thức thanh toán
    public IActionResult Index(string seat)
    {
        if (string.IsNullOrEmpty(seat))
        {
            // Nếu ghế chưa được chọn, điều hướng trở lại trang sự kiện hoặc hiển thị thông báo lỗi
            return RedirectToAction("EventDetail", "Event");
        }

        ViewBag.SelectedSeat = seat;  // Truyền ghế ngồi được chọn tới view
        return View();
    }

    // Xử lý thanh toán sau khi người dùng submit form
    [HttpPost]
    public IActionResult SubmitPayment(PaymentModel model)
    {
        if (ModelState.IsValid)
        {
            // Kiểm tra phương thức thanh toán đã chọn
            switch (model.SelectedPaymentMethod)
            {
                case "credit-card":
                    // Xử lý thanh toán qua thẻ tín dụng
                    ProcessCreditCardPayment(model);
                    break;
                case "paypal":
                    // Xử lý thanh toán qua PayPal
                    ProcessPayPalPayment(model);
                    break;
                case "e-wallet":
                    // Xử lý thanh toán qua ví điện tử
                    ProcessEWalletPayment(model);
                    break;
                default:
                    // Nếu không có phương thức nào được chọn, thêm lỗi vào ModelState
                    ModelState.AddModelError("", "Vui lòng chọn phương thức thanh toán.");
                    return View(model);
            }

            // Sau khi xử lý thanh toán thành công
            return RedirectToAction("PaymentSuccess"); // Chuyển hướng tới trang thành công
        }

        // Nếu ModelState không hợp lệ (có lỗi), trở lại view để hiển thị thông báo lỗi
        return View(model);
    }

    // Trang xác nhận thanh toán thành công
    public IActionResult PaymentSuccess()
    {
        return View();
    }

    // Phương thức xử lý thanh toán thẻ tín dụng (giả định)
    private void ProcessCreditCardPayment(PaymentModel model)
    {
        // Thêm logic tích hợp API thanh toán thẻ tín dụng tại đây
        // Ví dụ: Gọi đến một dịch vụ thanh toán và xử lý phản hồi
        // Lưu thông tin giao dịch vào cơ sở dữ liệu nếu cần
    }

    // Phương thức xử lý thanh toán qua PayPal (giả định)
    private void ProcessPayPalPayment(PaymentModel model)
    {
        // Thêm logic tích hợp với API PayPal tại đây
    }

    // Phương thức xử lý thanh toán qua ví điện tử (giả định)
    private void ProcessEWalletPayment(PaymentModel model)
    {
        // Thêm logic tích hợp với ví điện tử (Momo, ZaloPay, v.v.) tại đây
    }
}
