using ACStore.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ACStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AuditController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AuditController(ApplicationDbContext db)
        {
            _db = db;
        }

       
        public async Task<IActionResult> Index()
        {
            var now = DateTime.Now;

            var dueInstallments = await _db.Installments
                .Include(i => i.Order)
                    .ThenInclude(o => o!.Product)
                .Where(i => !i.IsPaid && i.DueDate.Month == now.Month && i.DueDate.Year == now.Year)
                .OrderBy(i => i.DueDate)
                .ToListAsync();

            return View(dueInstallments);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkAsPaid(int id)
        {
            var installment = await _db.Installments.FindAsync(id);
            if (installment != null)
            {
                installment.IsPaid = true;
                installment.PaidDate = DateTime.Now;

                _db.Payments.Add(new Models.Payment
                {
                    InstallmentID = installment.InstallmentID,
                    PaymentDate = DateTime.Now,
                    AmountPaid = installment.Amount
                });

                await _db.SaveChangesAsync();
                TempData["Success"] = "تم تسجيل الدفع بنجاح";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
