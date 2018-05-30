<?php
$username = 'YOURUSERNAME';
$password = 'YOURPASSWORD';
$PROXY_RACK_PORT = 222;
$PROXY_RACK_DNS = 'megaproxy.rotating.proxyrack.net';

$urlToGet = 'http://ip-api.com/json';
    $ch = curl_init();
    curl_setopt($ch, CURLOPT_URL, $urlToGet);
    curl_setopt($ch, CURLOPT_HEADER, 0);
    curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
    curl_setopt($ch, CURLOPT_PROXYPORT, $PROXY_RACK_PORT);
    curl_setopt($ch, CURLOPT_PROXYTYPE, 'HTTP');
    curl_setopt($ch, CURLOPT_PROXY, $PROXY_RACK_DNS);
    curl_setopt($ch, CURLOPT_PROXYUSERPWD, $username.':'.$password);
    $data = curl_exec($ch);
    curl_close($ch);

echo $data;
?>
