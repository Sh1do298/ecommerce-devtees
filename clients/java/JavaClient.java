import java.net.URI;
import java.net.http.HttpClient;
import java.net.http.HttpRequest;
import java.net.http.HttpResponse;

public class JavaClient {
    // ajuste a porta se sua API estiver diferente
    private static final String BASE = "http://localhost:5298/api/products";

    public static void main(String[] args) throws Exception {
        HttpClient http = HttpClient.newHttpClient();

        // POST /products
        String body = """
            {
              "name": "Camisa Java",
              "description": "Criada via cliente Java",
              "price": 59.90,
              "stock": 7,
              "categoryIds": []
            }
        """;

        HttpRequest post = HttpRequest.newBuilder()
                .uri(URI.create(BASE))
                .header("Content-Type", "application/json")
                .POST(HttpRequest.BodyPublishers.ofString(body))
                .build();

        HttpResponse<String> postResp = http.send(post, HttpResponse.BodyHandlers.ofString());
        System.out.println("POST status: " + postResp.statusCode());
        System.out.println("POST body  : " + postResp.body());

        // GET /products
        HttpRequest get = HttpRequest.newBuilder()
                .uri(URI.create(BASE))
                .GET()
                .build();

        HttpResponse<String> getResp = http.send(get, HttpResponse.BodyHandlers.ofString());
        System.out.println("GET status : " + getResp.statusCode());
        System.out.println("GET body   : " + getResp.body());
    }
}
