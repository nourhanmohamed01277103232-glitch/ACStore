using ACStore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ACStore.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProductsController(ApplicationDbContext db)
        {
            _db = db;
        }

       
        public async Task<IActionResult> Index(string? type)
        {
            var query = _db.Products.AsQueryable();

            if (!string.IsNullOrEmpty(type) && Enum.TryParse<Models.ProductType>(type, out var parsedType))
            {
                query = query.Where(p => p.Type == parsedType);
            }

            var products = await query.ToListAsync();
            ViewBag.SelectedType = type;
            return View(products);
        }

       
        public async Task<IActionResult> Details(int id)
        {
            var product = await _db.Products.FirstOrDefaultAsync(p => p.ProductID == id);
            if (product == null) return NotFound();

            return View(product);
        }
    }
}
