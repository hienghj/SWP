document.getElementById('payment-method').addEventListener('change', function () {
    const paymentMethod = this.value;
    const paymentInfoDiv = document.getElementById('payment-info');

    // Xóa nội dung cũ
    paymentInfoDiv.innerHTML = '';

    // Thêm thông tin thanh toán dựa trên phương thức được chọn
    const paymentFields = {
        'credit-card': `
            <div class="form-group">
                <label for="cardholder-name">Tên Chủ Thẻ:</label>
                <input type="text" id="cardholder-name" placeholder="Tên đầy đủ" required>
            </div>
            <div class="form-group">
                <label for="card-number">Số Thẻ:</label>
                <input type="text" id="card-number" placeholder="1234 5678 9012 3456" maxlength="16" required>
            </div>
            <div class="form-group">
                <label for="expiry-date">Ngày Hết Hạn:</label>
                <input type="text" id="expiry-date" placeholder="MM/YY" maxlength="5" required>
            </div>
            <div class="form-group">
                <label for="cvv">CVV:</label>
                <input type="text" id="cvv" placeholder="123" maxlength="3" required>
            </div>
        `,
        'paypal': `
            <div class="form-group">
                <label for="paypal-email">Email PayPal:</label>
                <input type="email" id="paypal-email" placeholder="email@example.com" required>
            </div>
        `,
        'e-wallet': `
            <div class="form-group">
                <label for="wallet-phone">Số Điện Thoại Liên Kết Với Ví Điện Tử:</label>
                <input type="tel" id="wallet-phone" placeholder="0123456789" required>
            </div>
        `
    };

    if (paymentFields[paymentMethod]) {
        paymentInfoDiv.innerHTML = paymentFields[paymentMethod];
        paymentInfoDiv.classList.remove('hidden');
    }
});

// Xử lý sự kiện khi form được submit
document.getElementById('payment-method-form').addEventListener('submit', async function (event) {
    event.preventDefault();

    const paymentMethod = document.getElementById('payment-method').value;
    if (!paymentMethod) {
        alert('Vui lòng chọn phương thức thanh toán.');
        return;
    }

    // Thu thập thông tin thanh toán
    let paymentInfo = {};
    if (paymentMethod === 'credit-card') {
        paymentInfo = {
            cardholderName: document.getElementById('cardholder-name').value,
            cardNumber: document.getElementById('card-number').value,
            expiryDate: document.getElementById('expiry-date').value,
            cvv: document.getElementById('cvv').value
        };
    } else if (paymentMethod === 'paypal') {
        paymentInfo = {
            paypalEmail: document.getElementById('paypal-email').value
        };
    } else if (paymentMethod === 'e-wallet') {
        paymentInfo = {
            walletPhone: document.getElementById('wallet-phone').value
        };
    }

    try {
        // Gửi dữ liệu thanh toán đến server
        const response = await fetch('/Booking/CompleteBooking', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                eventId: @Model.EventId,
                seatNumber: @Model.SeatNumber,
                paymentMethod: paymentMethod,
                paymentInfo: JSON.stringify(paymentInfo)
            })
        });

        const data = await response.json();

        if (data.success) {
            alert('Thanh toán thành công!');
            window.location.href = '/Profile'; // Redirect to user profile
        } else {
            alert('Thanh toán thất bại: ' + data.message);
        }
    } catch (error) {
        console.error('Error:', error);
        alert('Có lỗi xảy ra.');
    }
});
