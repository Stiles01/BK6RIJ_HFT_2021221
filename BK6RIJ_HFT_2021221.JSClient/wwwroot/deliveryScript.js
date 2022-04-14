let deliveries = [];
let connection = null;

getdata();
setupSignalR();


async function getdata() {
    fetch('http://localhost:9973/delivery')
        .then(x => x.json())
        .then(y => {
            deliveries = y;
            //console.log(customers);
            display();
        });
}


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:9973/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();
    connection.on("DeliveryCreated", (user, message) => {
        getdata();
    });
    connection.on("DeliveryDeleted", (user, message) => {
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

    deliveries.forEach(t => {
        table.innerHTML +=
            "<tr><td>" + t.id + "</td><td>" + t.company + "</td><td>" +
            t.deliveryDays + "</td><td>" + `<button type="button" onclick="remove(${t.id})">Delete</button>` + "</td></tr>";
        console.log(t.lcompany);
    });
}


function remove(id) {
    fetch('http://localhost:9973/delivery/' + id, {
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
    let company = document.getElementById('company').value;
    let deliveryDays = document.getElementById('deliverydays').value;

    fetch('http://localhost:9973/delivery', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                company: company,
                deliveryDays: deliveryDays
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