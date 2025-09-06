#include <iostream>
#include <string>
#include <curl/curl.h>

static size_t WriteCallback(void* contents, size_t size, size_t nmemb, void* userp) {
    ((std::string*)userp)->append((char*)contents, size * nmemb);
    return size * nmemb;
}

int main() {
    CURL* curl;
    CURLcode res;
    std::string readBuffer;

    curl_global_init(CURL_GLOBAL_DEFAULT);
    curl = curl_easy_init();
    if(curl) {
        // GET /products
        curl_easy_setopt(curl, CURLOPT_URL, "http://localhost:5298/api/products");
        curl_easy_setopt(curl, CURLOPT_WRITEFUNCTION, WriteCallback);
        curl_easy_setopt(curl, CURLOPT_WRITEDATA, &readBuffer);

        std::cout << "📦 Fazendo GET /products...\n";
        res = curl_easy_perform(curl);
        if(res == CURLE_OK) {
            std::cout << "Produtos: " << readBuffer << std::endl;
        } else {
            std::cerr << "Erro GET: " << curl_easy_strerror(res) << std::endl;
        }

        // POST /products
        const char* data = "{\"name\":\"Camisa C++\",\"description\":\"Criada via cliente C++\",\"price\":69.90,\"stock\":3,\"categoryIds\":[]}";
        struct curl_slist* headers = NULL;
        headers = curl_slist_append(headers, "Content-Type: application/json");

        curl_easy_setopt(curl, CURLOPT_URL, "http://localhost:5298/api/products");
        curl_easy_setopt(curl, CURLOPT_HTTPHEADER, headers);
        curl_easy_setopt(curl, CURLOPT_POSTFIELDS, data);

        readBuffer.clear();
        std::cout << "\n📦 Fazendo POST /products...\n";
        res = curl_easy_perform(curl);
        if(res == CURLE_OK) {
            std::cout << "Resposta criação: " << readBuffer << std::endl;
        } else {
            std::cerr << "Erro POST: " << curl_easy_strerror(res) << std::endl;
        }

        curl_easy_cleanup(curl);
        curl_slist_free_all(headers);
    }
    curl_global_cleanup();
    return 0;
}
