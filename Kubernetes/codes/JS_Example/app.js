const http = require('http');
const os = require('os');

console.log("Yanchen Kubia server starting...");

var handler = function(request, response) {
	console.log("Let's start");
	console.log("Received request from " + request.connection.remoteAddress);
	response.writeHead(200);
	response.end("You've hit " + os.hosename() + "\n");
};

var www = http.createServer(handler);
www.listen(8080);
