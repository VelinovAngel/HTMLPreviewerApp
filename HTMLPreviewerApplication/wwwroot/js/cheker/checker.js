(() => {
    const check = () => {

        const htmlCode = document.getElementById('htmlCodeInput').value;
        const message = document.getElementById('alertMessage');
        const RequestVerificationToken = document.querySelector("input[name='__RequestVerificationToken']").value;

        fetch('/api/checker',
            {
                method: 'POST',
                headers: {
                    "Content-Type": "application/json",
                    'X-CSRF-TOKEN': RequestVerificationToken
                },
                body: JSON.stringify({ htmlCode: htmlCode })
            })
            .then(res => res.json())
            .then(res => {
                if (res) {
                    message.textContent = 'The HTML Code already exist!';
                    message.className = 'alert alert-danger alert-dismissible fade show visible';
                } else {
                    message.textContent = 'The HTML Code doesn\'t exist';
                    message.className = 'alert alert-success alert-dismissible fade show visible';

                }
            })
            .catch(err => alert(err.message));
    }

    const checkBtn = document.getElementById('checkButton');
    checkBtn.addEventListener('click', check);

})();