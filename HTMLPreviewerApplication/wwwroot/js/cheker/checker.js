(() => {
    const check = () => {
        const htmlCode = document.getElementById('htmlCodeInput').value;

        const token = document.querySelector("input[name='__RequestVerificationToken']").value;

        fetch('/api/checker',
            {
                method: 'POST',
                headers: {
                    "Content-Type": "application/json",
                    'X-CSRF-TOKEN': token
                },
                body: JSON.stringify({htmlCode: htmlCode })
            })
            .then(res => res.json())
            .catch();
    }

    const checkBtn = document.getElementById('checkButton');
    checkBtn.addEventListener('click', check);

})();