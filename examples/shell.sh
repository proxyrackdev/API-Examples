#!/usr/bin/env bash

export USERNAME=YOURUSERNAME
export PASSWORD=YOURPASSWORD
export PROXY_RACK_DNS=megaproxy.rotating.proxyrack.net:222
curl -x http://$USERNAME:$PASSWORD@$PROXY_RACK_DNS http://ip-api.com/json && echo
