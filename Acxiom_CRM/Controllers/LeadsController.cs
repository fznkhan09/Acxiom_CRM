
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Acxiom_CRM.Models;
using Acxiom_CRM.Data;

public class LeadsController : Controller
{
    private readonly ApplicationDbContext _context;

    public LeadsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: LEADS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Leads.ToListAsync());
    }

    // GET: LEADS/Details/5
    public async Task<IActionResult> Details(int? leadid)
    {
        if (leadid == null)
        {
            return NotFound();
        }

        var lead = await _context.Leads
            .FirstOrDefaultAsync(m => m.LeadId == leadid);
        if (lead == null)
        {
            return NotFound();
        }

        return View(lead);
    }

    // GET: LEADS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: LEADS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("LeadId,LeadName,CompanyName,Email,Phone,LeadSource,LeadStatus,ExpectedValue,CreatedDate")] Lead lead)
    {
        if (ModelState.IsValid)
        {
            _context.Add(lead);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(lead);
    }

    // GET: LEADS/Edit/5
    public async Task<IActionResult> Edit(int? leadid)
    {
        if (leadid == null)
        {
            return NotFound();
        }

        var lead = await _context.Leads.FindAsync(leadid);
        if (lead == null)
        {
            return NotFound();
        }
        return View(lead);
    }

    // POST: LEADS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? leadid, [Bind("LeadId,LeadName,CompanyName,Email,Phone,LeadSource,LeadStatus,ExpectedValue,CreatedDate")] Lead lead)
    {
        if (leadid != lead.LeadId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(lead);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeadExists(lead.LeadId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(lead);
    }

    // GET: LEADS/Delete/5
    public async Task<IActionResult> Delete(int? leadid)
    {
        if (leadid == null)
        {
            return NotFound();
        }

        var lead = await _context.Leads
            .FirstOrDefaultAsync(m => m.LeadId == leadid);
        if (lead == null)
        {
            return NotFound();
        }

        return View(lead);
    }

    // POST: LEADS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? leadid)
    {
        var lead = await _context.Leads.FindAsync(leadid);
        if (lead != null)
        {
            _context.Leads.Remove(lead);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool LeadExists(int? leadid)
    {
        return _context.Leads.Any(e => e.LeadId == leadid);
    }
}
