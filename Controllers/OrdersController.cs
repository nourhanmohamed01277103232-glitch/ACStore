using ACStore.Data;
using ACStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ACStore.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _db;

        public OrdersController(ApplicationDbContext db)
        {
            _db = db;
        }

      
        public async Task<IActionResult> Create(int productId)
        {
            var product = await _db.Products.FirstOrDefaultAsync(p => p.ProductID == productId);
            if (product == null) return NotFound();

            var order = new Order { ProductID = productId, Product = product };
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Order order)
        {
            var product = await _db.Products.FirstOrDefaultAsync(p => p.ProductID == order.ProductID);
            if (product == null) return NotFound();

            if (product.StockQuantity <= 0)
            {
                ModelState.AddModelError("", "عذرًا، هذا المنتج غير متوفر حاليًا في المخزون.");
                order.Product = product;
                return View(order);
            }

            if (!ModelState.IsValid)
            {
                order.Product = product;
                return View(order);
            }

            order.OrderDate = DateTime.Now;
            order.TotalAmount = product.Price;

            if (order.PaymentType == PaymentType.Installment && order.DownPayment.HasValue && order.DurationMonths.HasValue)
            {
                var remaining = order.TotalAmount - order.DownPayment.Value;
                var monthlyAmount = Math.Round(remaining / order.DurationMonths.Value, 2);

                for (int i = 1; i <= order.DurationMonths.Value; i++)
                {
                    order.Installments.Add(new Installment
                    {
                        InstallmentNumber = i,
                        DueDate = DateTime.Now.AddMonths(i),
                        Amount = monthlyAmount,
                        IsPaid = false
                    });
                }
            }

         
            product.StockQuantity -= 1;

            _db.Orders.Add(order);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Confirmation), new { id = order.OrderID });
        }

        public async Task<IActionResult> Confirmation(int id)
        {
            var order = await _db.Orders
                .Include(o => o.Product)
                .Include(o => o.Installments)
                .FirstOrDefaultAsync(o => o.OrderID == id);

            if (order == null) return NotFound();
            return View(order);
        }
    }
}
