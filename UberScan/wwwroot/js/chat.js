var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

connection.on("ReceiveMessage", function (user, message) {

    var msg = message.replace(/&/g, "&")
        .replace(/&/g, ">");
    var encodedMsg = "<span class='text-yellow-500 italic mr-1'>" + user + "</span>" + ": " + msg;

    var p = document.createElement("p");
    p.innerHTML = encodedMsg;
    document.getElementById("messagesList").appendChild(p);
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});