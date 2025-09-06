import requests

BASE_URL = "http://localhost:5298/api/products"

def get_products():
    """Faz um GET em /products e imprime a lista."""
    try:
        response = requests.get(BASE_URL, timeout=5)
        response.raise_for_status()
        print("📦 Produtos cadastrados:")
        for p in response.json():
            print(f"- {p['id']}: {p['name']} (R$ {p['price']})")
    except Exception as e:
        print("Erro ao buscar produtos:", e)


def create_product():
    """Faz um POST em /products criando um novo produto."""
    payload = {
        "name": "Camisa Python",
        "description": "Criada via cliente Python",
        "price": 49.90,
        "stock": 5,
        "categoryIds": []  # pode incluir IDs válidos se já tiver categorias
    }
    try:
        response = requests.post(BASE_URL, json=payload, timeout=5)
        response.raise_for_status()
        print("✅ Produto criado:", response.json())
    except Exception as e:
        print("Erro ao criar produto:", e)


if __name__ == "__main__":
    # 1. Cria um produto de teste
    create_product()

    # 2. Lista os produtos
    get_products()
