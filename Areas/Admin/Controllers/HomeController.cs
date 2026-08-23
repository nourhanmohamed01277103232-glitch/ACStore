using ACStore.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ACStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.TotalProducts = await _db.Products.CountAsync();
            ViewBag.LowStockCount = await _db.Products.CountAsync(p => p.StockQuantity <= 3);
            ViewBag.TotalOrders = await _db.Orders.CountAsync();
            ViewBag.PendingInstallments = await _db.Installments.CountAsync(i => !i.IsPaid);

            return View();
        }
    }
}
