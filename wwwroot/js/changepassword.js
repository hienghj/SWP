document.addEventListener('DOMContentLoaded', function () {
    const currentPasswordInput = document.getElementById('current-password');
    const newPasswordSection = document.getElementById('new-password-section');
    const errorMessage = document.getElementById('error-message');

    document.getElementById('current-password').addEventListener('blur', function () {
        const currentPassword = currentPasswordInput.value;

        fetch('/ChangePassword/VerifyCurrentPassword', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ currentPassword: currentPassword })
        })
            .then(response => response.json())
            .then(data => {
                if (data.success) {
                    newPasswordSection.style.display = 'block';
                    errorMessage.style.display = 'none';
                } else {
                    newPasswordSection.style.display = 'none';
                    errorMessage.style.display = 'block';
                }
            })
            .catch(error => {
                console.error('Error verifying password:', error);
            });
    });

});
