document.addEventListener('DOMContentLoaded', function () {
    const updateProfileBtn = document.getElementById('update-profile-btn');
    const changePasswordBtn = document.getElementById('change-password-btn');
    const bookingHistoryContainer = document.getElementById('booking-history-container');
    const tableBody = document.querySelector('#ticket-table tbody');
 
    // Hiển thị lịch sử đặt vé
    function displayBookingHistory(bookings) {
        bookingHistoryContainer.innerHTML = '';

        bookings.forEach(booking => {
            const bookingItem = document.createElement('div');
            bookingItem.className = 'event-item';
            bookingItem.innerHTML = `
                <h3>${booking.title}</h3>
                <p><strong>Ngày:</strong> ${booking.date}</p>
                <p><strong>Địa điểm:</strong> ${booking.location}</p>
            `;
            bookingHistoryContainer.appendChild(bookingItem);
        });
    }

    // Hiển thị danh sách vé
    function displayTickets(tickets) {
        tableBody.innerHTML = ''; // Xóa nội dung trước khi hiển thị mới

        tickets.forEach(ticket => {
            const row = document.createElement('tr');
            row.id = `ticket-${ticket.ticket_id}`; // Đặt ID cho hàng
            row.innerHTML = `
                <td>${ticket.ticket_id}</td>
                <td>${ticket.event_title}</td>
                <td>${ticket.seat_number}</td>
                <td>${ticket.purchase_date}</td>
                <td><a href="#">${ticket.qr_code}</a></td>
                <td>
                    <button class="cancel" onclick="openModal('cancel-modal', ${ticket.ticket_id})">Hủy</button>
                    <button class="transfer" onclick="openModal('transfer-modal', ${ticket.ticket_id})">Chuyển Nhượng</button>
                    <button class="qr-code" onclick="openQRCodeModal('${ticket.qr_code}')">Tải Mã QR</button>
                </td>
            `;
            tableBody.appendChild(row);
        });
    }

    document.addEventListener('DOMContentLoaded', function () {
        const updateProfileBtn = document.getElementById('update-profile-btn');
        // Redirect to the UpdateProfile action when the button is clicked
        updateProfileBtn.addEventListener('click', function () {
            window.location.href = '/Profile/UpdateProfile'; // Adjust the path as necessary
        });
    });


    // Xử lý sự kiện khi bấm nút thay đổi mật khẩu
    changePasswordBtn.addEventListener('click', function () {
        window.location.href = 'ChangePassword.cshtml';
    });

    // Hiển thị lịch sử đặt vé và danh sách vé
    displayBookingHistory(dummyBookings);
    displayTickets(tickets);
});

// Mở modal với ID cụ thể và lưu ID vé hiện tại
function openModal(modalId, ticketId) {
    document.getElementById(modalId).style.display = 'block';
    window.currentTicketId = ticketId;
}

// Đóng modal với ID cụ thể
function closeModal(modalId) {
    document.getElementById(modalId).style.display = 'none';
}

// Xác nhận hủy vé
function confirmCancel() {
    if (confirm('Bạn có chắc chắn muốn hủy vé này?')) {
        // Xóa hàng vé khỏi bảng
        const ticketRow = document.getElementById(`ticket-${window.currentTicketId}`);
        if (ticketRow) {
            ticketRow.remove();
        }
        alert(`Vé ID ${window.currentTicketId} đã bị hủy.`);
        closeModal('cancel-modal');
    }
}

// Xác nhận chuyển nhượng vé
function confirmTransfer() {
    const newOwner = document.getElementById('new-owner').value;
    if (newOwner) {
        // Xóa hàng vé khỏi bảng
        const ticketRow = document.getElementById(`ticket-${window.currentTicketId}`);
        if (ticketRow) {
            ticketRow.remove();
        }
        alert(`Vé ID ${window.currentTicketId} đã được chuyển nhượng cho ${newOwner}.`);
        closeModal('transfer-modal');
    } else {
        alert('Vui lòng nhập thông tin người nhận mới.');
    }
}

// Mở modal mã QR để tải
function openQRCodeModal(qrCode) {
    const qrDownloadLink = document.getElementById('qr-download-link');
    qrDownloadLink.href = `path/to/qr-code-images/${qrCode}.png`; // Cập nhật đường dẫn đến hình ảnh mã QR
    document.getElementById('qr-modal').style.display = 'block';
}

// Xử lý tải mã QR
function downloadQRCode() {
    alert('Tải mã QR đã được xử lý.');
    closeModal('qr-modal');
}
