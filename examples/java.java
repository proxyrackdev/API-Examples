import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.*;

public class Application {
    private static String USERNAME = "YOURUSERNAME";
    private static String PASSWORD = "YOURPASSWORD";

    private static String PROXY_RACK_DNS = "megaproxy.rotating.proxyrack.net";
    private static int PROXYRACK_PORT = 222;

    private static String URL_TO_GET = "http://ip-api.com/json";

    public static void main(String[] args) throws IOException {
        final Proxy proxy = new Proxy(Proxy.Type.HTTP, new InetSocketAddress(PROXY_RACK_DNS, PROXYRACK_PORT));
        Authenticator.setDefault(
                new Authenticator() {
                    public PasswordAuthentication getPasswordAuthentication() {
                        return new PasswordAuthentication(
                                USERNAME, PASSWORD.toCharArray()
                        );
                    }
                }
        );

        final URL url = new URL(URL_TO_GET);
        final URLConnection urlConnection = url.openConnection(proxy);

        final BufferedReader bufferedReader = new BufferedReader(
                new InputStreamReader(urlConnection.getInputStream()));
        final StringBuilder response = new StringBuilder();

        String inputLine;
        while ((inputLine = bufferedReader.readLine()) != null) {
            response.append(inputLine);
        }
        bufferedReader.close();

        System.out.println(String.format("Response:\n%s", response.toString()));
    }
}
