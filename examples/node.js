var request = require('request');

var username = 'YOURUSERNAME';
var password = 'YOURPASSWORD';
var PROXY_RACK_DNS = 'unmetered.residential.proxyrack.net';
var PROXYRACK_PORT = 9000;

var proxyUrl = "http://" + username + ":" + password + "@" + PROXY_RACK_DNS + ":" + PROXYRACK_PORT;
var proxiedRequest = request.defaults({'proxy': proxyUrl});

proxiedRequest.get("http://ipinfo.io", function (err, resp, body) {
    console.log('error = ', err);
    console.log('body = ', body);
})
