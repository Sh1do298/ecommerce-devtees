using Microsoft.AspNetCore.Mvc;
using Ecommerce.Api.Data;
using Ecommerce.Api.Models;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase {
    private readonly AppDbContext _db;
    public ProductsController(AppDbContext db) => _db = db;

    [HttpGet]
    public IActionResult GetAll() => Ok(_db.Products.ToList());

    [HttpPost]
    public IActionResult Create(Product p) {
        _db.Products.Add(p);
        _db.SaveChanges();
        return CreatedAtAction(nameof(GetAll), new { id = p.Id }, p);
    }
}
