var request = require('request');

var username = 'YOURUSERNAME';
var password = 'YOURPASSWORD';
var PROXY_RACK_DNS = 'megaproxy.rotating.proxyrack.net';
var PROXYRACK_PORT = 222;

var proxyUrl = "http://" + username + ":" + password + "@" + PROXY_RACK_DNS + ":" + PROXYRACK_PORT;
var proxiedRequest = request.defaults({'proxy': proxyUrl});

proxiedRequest.get("http://ip-api.com/json", function (err, resp, body) {
    console.log('error = ', err);
    console.log('body = ', body);
})
