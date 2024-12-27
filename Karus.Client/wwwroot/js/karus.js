document.addEventListener('DOMContentLoaded', function () {

    const backButtons = document.querySelectorAll('.btn-icon-back');

    if (backButtons.length > 0) {
        backButtons.forEach(button => {
            button.addEventListener('click', function () {
                history.back();
            });
        });
    }
});
