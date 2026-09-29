using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Acxiom_CRM.Models;
using Acxiom_CRM.Data;

namespace Acxiom_CRM.Controllers
{
    [Authorize]
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Customers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Customers.ToListAsync());
        }

        // GET: /Customers/Details?customerid=5
        public async Task<IActionResult> Details(int? customerid)
        {
            if (customerid == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(x => x.CustomerId == customerid);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: /Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("CustomerId,CustomerName,Email,Phone,CompanyName,City,Pincode,IsActive,CreatedDate")]
            Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(customer);
        }

        // GET: /Customers/Edit?customerid=5
        public async Task<IActionResult> Edit(int? customerid)
        {
            if (customerid == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(customerid);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: /Customers/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int customerid,
            [Bind("CustomerId,CustomerName,Email,Phone,CompanyName,City,Pincode,IsActive,CreatedDate")]
            Customer customer)
        {
            if (customerid != customer.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.CustomerId))
                    {
                        return NotFound();
                    }

                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(customer);
        }

        // GET: /Customers/Delete?customerid=5
        public async Task<IActionResult> Delete(int? customerid)
        {
            if (customerid == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(x => x.CustomerId == customerid);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: /Customers/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int customerid)
        {
            var customer = await _context.Customers.FindAsync(customerid);

            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int customerid)
        {
            return _context.Customers
                .Any(e => e.CustomerId == customerid);
        }
    }
}