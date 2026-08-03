fetch('https://localhost:7026/api/custom-headers/middleware')
    .then(response => { 
        response.headers.forEach(function(value,name) { 
            console.log(name + ": " + value); 
        }); 
    })