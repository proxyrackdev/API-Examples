package main

import (
	"fmt"
	"io/ioutil"
	"net/http"
	"net/url"
	"os"
)

const(
	proxyUrlTemplate = "http://%s:%s@%s:%s"
)

const (
	username = "YOURUSERNAME"
	password = "YOURPASSWORD"

	PROXY_RACK_DNS = "unmetered.residential.proxyrack.net"
	PROXYRACK_PORT = "9000"

	urlToGet = "http://ipinfo.io"
)

func main() {
	proxy := fmt.Sprintf(proxyUrlTemplate, username, password, PROXY_RACK_DNS, PROXYRACK_PORT)
	proxyURL, err := url.Parse(proxy)
	if err != nil {
		fmt.Printf("failed to form proxy URL: %v", err)
		os.Exit(1)
	}

	u, err := url.Parse(urlToGet)
	if err != nil {
		fmt.Printf("failed to form GET request URL: %v", err)
		os.Exit(1)
	}

	transport := &http.Transport{Proxy: http.ProxyURL(proxyURL)}
	client := &http.Client{Transport: transport}

	request, err := http.NewRequest("GET", u.String(), nil)
	if err != nil {
		fmt.Printf("failed to form GET request: %v", err)
		os.Exit(1)
	}

	response, err := client.Do(request)
	if err != nil {
		fmt.Printf("failed to perform GET request: %v", err)
		os.Exit(1)
	}
	defer response.Body.Close()

	responseBodyBytes, err := ioutil.ReadAll(response.Body)
	if err != nil {
		fmt.Printf("could not read response body bytes: %v", err)
		os.Exit(1)
	}
	fmt.Printf("Response:\n%s\n", string(responseBodyBytes))
}
