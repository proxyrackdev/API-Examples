#!/usr/bin/env python3

import requests

username = "vranesevic"
password = "svranesevic"

PROXY_RACK_DNS = "megaproxy.rotating.proxyrack.net:222"

urlToGet = "http://ip-api.com/json"

proxy = {"http":"http://{}:{}@{}".format(username, password, PROXY_RACK_DNS)}

r = requests.get(urlToGet , proxies=proxy)

print("Response:\n{}".format(r.text))