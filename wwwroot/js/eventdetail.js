<script src="https://maps.googleapis.com/maps/api/js?key=YOUR_API_KEY&callback=initMap" async defer></script>
<script>
    document.addEventListener('DOMContentLoaded', function () {
        // 1. Kiểm tra ghế đã đặt và vô hiệu hóa
        var bookedSeats = [/* ghế đã được đặt từ backend */];
        bookedSeats.forEach(function (seatNumber) {
            var seatOption = document.querySelector('#seatSelection option[value="' + seatNumber + '"]');
            if (seatOption) {
                seatOption.disabled = true;
                seatOption.text += " (Đã Đặt)";
            }
        });

        // 2. Đặt vé qua AJAX
        document.getElementById('bookTicketBtn').addEventListener('click', function () {
            var selectedSeat = document.getElementById('seatSelection').value;

            fetch('/Booking/BookTicket', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    'X-CSRF-TOKEN': document.querySelector('input[name="__RequestVerificationToken"]').value
                },
                body: JSON.stringify({ eventId: @Model.Id, seatNumber: selectedSeat })
            })
            .then(response => response.json())
            .then(data => {
                if (data.success) {
                    alert("Đặt vé thành công!");
                    location.reload(); // Cập nhật lại trang sau khi đặt vé
                } else {
                    alert("Đặt vé thất bại!");
                }
            })
            .catch(error => console.error('Error:', error));
        });

        // 3. Hiển thị bản đồ Google Maps
        function initMap() {
            var location = { lat: @Model.Latitude, lng: @Model.Longitude }; // Sử dụng tọa độ từ Model
            var map = new google.maps.Map(document.getElementById('map'), {
                zoom: 15,
                center: location
            });

            var marker = new google.maps.Marker({
                position: location,
                map: map
            });
        }
    });

    function bookTicket() {
    var selectedSeat = document.getElementById("seatSelection").value;
    if (selectedSeat) {
        window.location.href = '/Payment/Index?seat=' + selectedSeat;
    } else {
        alert("Vui lòng chọn chỗ ngồi trước khi đặt vé.");
    }
}

</script>
