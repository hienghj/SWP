document.addEventListener('DOMContentLoaded', function () {
    const saveBtn = document.getElementById('save-btn');
    const backBtn = document.getElementById('back-btn');

    backBtn.addEventListener('click', function () {
        window.location.href = '@Url.Action("Profile", "Profile")';
    });
});
