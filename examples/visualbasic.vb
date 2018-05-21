Imports System.IO
Imports System.Net

Module Module1

    Private Const Username As String = "YOURUSERNAME"
    Private Const Password As String = "YOURPASSWORD"
    Private Const PROXY_RACK_DNS As String = "http://megaproxy.rotating.proxyrack.net:222"
    Private Const UrlToGet As String = "http://ip-api.com/json"

    Sub Main()
        Dim httpWebRequest = CType(WebRequest.Create(UrlToGet), HttpWebRequest)
        Dim webProxy = New WebProxy(New Uri(PROXY_RACK_DNS)) With {
                .Credentials = New NetworkCredential(Username, Password)
                }
        httpWebRequest.Proxy = webProxy
        Dim httpWebResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)
        Dim responseStream = httpWebResponse.GetResponseStream()

        If responseStream Is Nothing Then
            Return
        End If

        Dim responseString = New StreamReader(responseStream).ReadToEnd()
        Console.WriteLine($"Response:\n{responseString}")
        Console.ReadKey()
    End Sub

End Module
