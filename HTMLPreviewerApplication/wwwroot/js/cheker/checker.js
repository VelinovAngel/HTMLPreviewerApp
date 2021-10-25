(() => {
    const check = () => {
        const id = document.getElementById('sample-id').value;
        const htmlCode = document.getElementById('htmlCodeInput').value;

        const token = document.querySelector("input[name='__RequestVerificationToken']").value;

        fetch('/api/checker',
            {
                method: 'POST',
                headers: {
                    "Content-Type": "application/json",
                    'X-CSRF-TOKEN': token
                },
                body: JSON.stringify({ id: id, htmlCode: htmlCode })
            })
            .then(res => res.json())
            .then(res => {
                if (res) {
                    message.textContent = 'Already exist';
                } else {
                    message.textContent = 'Not exist!';
                }
            })
            .catch(err => alert(err.message));
    }

    const checkBtn = document.getElementById('checkButton');
    checkBtn.addEventListener('click', check);

})();