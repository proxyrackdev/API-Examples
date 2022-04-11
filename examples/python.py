#!/usr/bin/env python3

import requests

username = "YOURUSERNAME"
password = "YOURPASSWORD"

PROXY_RACK_DNS = "unmetered.residential.proxyrack.net:222"

urlToGet = "http://ipinfo.io"

proxy = {"http":"http://{}:{}@{}".format(username, password, PROXY_RACK_DNS)}

r = requests.get(urlToGet , proxies=proxy)

print("Response:\n{}".format(r.text))
