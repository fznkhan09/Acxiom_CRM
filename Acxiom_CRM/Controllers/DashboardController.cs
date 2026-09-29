using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Acxiom_CRM.Data;

namespace Acxiom_CRM.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.TotalCustomers =
                _context.Customers.Count();

            ViewBag.TotalLeads =
                _context.Leads.Count();

            ViewBag.OpenOpportunities =
                _context.Opportunities
                    .Count(x => x.Status == "Open");

            ViewBag.WonOpportunities =
                _context.Opportunities
                    .Count(x => x.Status == "Won");

            ViewBag.TotalSales =
                _context.Opportunities
                    .Where(x => x.Status == "Won")
                    .Sum(x => (decimal?)x.Amount) ?? 0;

            ViewBag.PendingFollowUps =
                _context.FollowUps
                    .Count(x => x.Status == "Pending");

            return View();
        }
    }
}