using Microsoft.AspNetCore.Mvc;
using Ecommerce.Api.Data;
using Ecommerce.Api.Models;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase {
    private readonly AppDbContext _db;
    public ProductsController(AppDbContext db) => _db = db;

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id) {
        var product = _db.Products
            .Include(p => p.ProductCategories)
            .ThenInclude(pc => pc.Category)
            .Where(p => p.Id == id)
            .Select(p => new ProductReadDto(
                p.Id, p.Name, p.Description, p.Price, p.Stock, p.CreatedAt,
                p.ProductCategories.Select(pc => pc.Category.Name).ToList()
            ))
            .FirstOrDefault();

        return product is null ? NotFound(new { message = "Produto não encontrado" }) : Ok(product);
    }


    [HttpPost]
    public IActionResult Create(Product p) {
        _db.Products.Add(p);
        _db.SaveChanges();
        return CreatedAtAction(nameof(GetAll), new { id = p.Id }, p);
    }
}
