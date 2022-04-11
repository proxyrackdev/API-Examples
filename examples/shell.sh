#!/usr/bin/env bash

export USERNAME=YOURUSERNAME
export PASSWORD=YOURPASSWORD
export PROXY_RACK_DNS=unmetered.residential.proxyrack.net:9000
curl -x http://$USERNAME:$PASSWORD@$PROXY_RACK_DNS http://ipinfo.io && echo
