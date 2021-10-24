
const btn = document.getElementById('redering');
btn.addEventListener('click', renderhtml);

function renderhtml(ev) {
    ev.preventDefault();

    const htmlInput = document.getElementById('htmlCodeInput');
    const htmlOutput = document.getElementById('htmlCodeOutput');

    htmlOutput.innerHTML = htmlInput.value;
}

