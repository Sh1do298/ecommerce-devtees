namespace Ecommerce.Api.Dtos;

// Entrada (quando cliente cria produto)
public record ProductCreateDto(
    string Name,
    string Description,
    decimal Price,
    int Stock,
    List<int>? CategoryIds
);

// Saída (quando devolvemos produto para cliente)
public record ProductReadDto(
    int Id,
    string Name,
    string Description,
    decimal Price,
    int Stock,
    DateTime CreatedAt,
    List<string> Categories
);
