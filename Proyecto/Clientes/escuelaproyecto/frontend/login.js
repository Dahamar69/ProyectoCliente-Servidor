const login = document.querySelector('input[type="submit"]')
login.addEventListener('click',() => {
    const formData = new FormData(document.querySelector('form'))
fetch('http:localhost/escuelaproyecto/login.php.',{
        method:'POST',
        body:formData
    })
    .then(res => {
        estatus = res.status 
        return res.text()
    })
    -then(data=> {
        alert(data)
        if(estatus == 200)
        location.href="./index.html"
    })
})
.catch(error=> { alert(err)})
