let products = [];
let connection = null;

let productIdToUpdate = -1;

getdata();
setupSignalR();


async function getdata() {
    fetch('http://localhost:9973/product')
        .then(x => x.json())
        .then(y => {
            products = y;
            //console.log(customers);
            display();
        });
}


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:9973/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();
    connection.on("ProductCreated", (user, message) => {
        getdata();
    });
    connection.on("ProductDeleted", (user, message) => {
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

    products.forEach(t => {
        table.innerHTML +=
            "<tr><td>" + t.id + "</td><td>" + t.name + "</td><td>" +
            t.price + "</td><td>" + `<button type="button" onclick="remove(${t.id})">Delete</button><button type="button" onclick="showupdate(${t.id})">Update</button>` + "</td></tr>";
        console.log(t.name);
    });
}

function showupdate(id) {
    document.getElementById('nametoupdate').value = products.find(t => t['id'] == id)['name'];
    document.getElementById('pricetoupdate').value = products.find(t => t['id'] == id)['price'];
    document.getElementById('updatediv').style.display = 'flex';
    productIdToUpdate = id;
}


function remove(id) {
    fetch('http://localhost:9973/product/' + id, {
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
    let name = document.getElementById('name').value;
    let price = document.getElementById('price').value;

    fetch('http://localhost:9973/product', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                name: name,
                price: price
            }),
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

function update() {
    document.getElementById('updatediv').style.display = 'none';
    let name = document.getElementById('nametoupdate').value;
    let price = document.getElementById('pricetoupdate').value;

    fetch('http://localhost:9973/product', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                id: productIdToUpdate,
                name: name,
                price: price
            }),
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