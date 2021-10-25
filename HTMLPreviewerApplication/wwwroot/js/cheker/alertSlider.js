(() => {
    const check = () => {
        $("#alertMessage").fadeTo(2000, 1000).slideUp(1000, function () {
            $("#alertMessage").slideUp(1000);
        });
    }
    const checkBtn = document.getElementById('checkButton');
    checkBtn.addEventListener('click', check);

})();
