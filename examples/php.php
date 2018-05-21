<?php
$username = 'YOURUSERNAME';
$password = 'YOURPASSWORD';

$PROXY_RACK_DNS = 'http://megaproxy.rotating.proxyrack.net:222';

$urlToGet = "http://ip-api.com/json";

$auth = base64_encode($username.':'.$password);
$aContext = array(
    'http' => array(
        'proxy' => 'tcp://' . PROXY_RACK_DNS,
        'request_fulluri' => true,
        'header' => "Proxy-Authorization: Basic $auth",
    ),
);
$cxContext = stream_context_create($aContext);

$contents = file_get_contents($urlToGet, False, $cxContext);

if($contents !== false){
    echo $contents;
}
?>
