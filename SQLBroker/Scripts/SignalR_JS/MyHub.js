$(function () {
    // Declare a proxy to reference the hub.
    var chat = $.connection.myHub;

    // Create a function that the hub can call to broadcast messages.
    chat.client.Test = function (data) {
        $('li').remove(".list");
        for (var i = 0; i < data.length; i++) {
            // Html encode display name and message.
            var encodedName = $('<div />').text(data[i].Name).html();
            var encodedMsg = $('<div />').text(data[i].Email).html();
            // Add the message to the page.
            $('#discussion').append('<li class ="list"><strong>' + encodedName + '</strong>:&nbsp;&nbsp;' + encodedMsg + '</li>');
            //console.log(data[i].Name+":"+ data[i].Email);
        }
        console.log("123");
    };
    // Start the connection.
    $.connection.hub.start().done(function () {
        //chat.server.testMessage();
    });
    
    
});