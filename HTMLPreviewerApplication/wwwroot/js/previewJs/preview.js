//function redering() {
//    const btn = document.getElementById('redering');
//    btn.addEventListener('click', renderHtml);

//    function renderHtml(ev) {
//        ev.preventDefault();

//        const htmlInput = document.getElementById('htmlCodeInput');
//        const htmlOutput = document.getElementById('htmlCodeOutput');

//        htmlOutput.innerHTML = htmlInput.value;
//    }
//}



(() => {
    const htmlCodeOutput = document.getElementById('htmlCodeOutput');

    const preview = (e) => {
        const target = e.target;

        htmlCodeOutput.innerHTML = target.value;
    };

    document.getElementById('htmlCodeInput')
        .addEventListener('input', preview);
})();
