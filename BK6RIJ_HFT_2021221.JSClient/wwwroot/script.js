let customers = [];
let connection = null;

getdata();
setupSignalR();


async function getdata() {
    fetch('http://localhost:9973/customer')
        .then(x => x.json())
        .then(y => {
            customers = y;
            //console.log(customers);
            display();
        });
}


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:9973/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();
    connection.on("CustomerCreated", (user, message) => {
        getdata();
    });
    connection.on("CustomerDeleted", (user, message) => {
        getdata();
    });

    connection.onclose
        (async () => {
            await start();
        });
    start();
}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
}

function display() {
    let table = document.getElementById('resultarea');
    table.innerHTML = "";

    customers.forEach(t => {
        table.innerHTML +=
            "<tr><td>" + t.id + "</td><td>" + t.lastName + "</td><td>" +
             t.firstName + "</td><td>" + `<button type="button" onclick="remove(${t.id})">Delete</button>` + "</td></tr>";
        console.log(t.lastName + ' ' + t.firstName);
    });
}


function remove(id){
    fetch('http://localhost:9973/customer/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}

function create() {
    let lastname = document.getElementById('lastname').value;
    let firstname = document.getElementById('firstname').value;

    fetch('http://localhost:9973/customer', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                firstName: firstname,
                lastName: lastname
            }),})
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });

    
}