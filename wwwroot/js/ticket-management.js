<script>
    document.addEventListener('DOMContentLoaded', function() {
        const transferForms = document.querySelectorAll('form[action="TransferTicket"]');
    const cancelForms = document.querySelectorAll('form[action="CancelTicket"]');

        transferForms.forEach(form => {
        form.addEventListener('submit', function (event) {
            const confirmTransfer = confirm("Bạn có chắc chắn muốn chuyển nhượng vé này?");
            if (!confirmTransfer) {
                event.preventDefault();
            }
        });
        });

        cancelForms.forEach(form => {
        form.addEventListener('submit', function (event) {
            const confirmCancel = confirm("Bạn có chắc chắn muốn hủy vé này?");
            if (!confirmCancel) {
                event.preventDefault();
            }
        });
        });
    });
</script>