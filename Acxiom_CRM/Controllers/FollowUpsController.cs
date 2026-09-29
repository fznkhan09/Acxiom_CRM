
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Acxiom_CRM.Models;
using Acxiom_CRM.Data;

public class FollowUpsController : Controller
{
    private readonly ApplicationDbContext _context;

    public FollowUpsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: FOLLOWUPS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.FollowUps.ToListAsync());
    }

    // GET: FOLLOWUPS/Details/5
    public async Task<IActionResult> Details(int? followupid)
    {
        if (followupid == null)
        {
            return NotFound();
        }

        var followup = await _context.FollowUps
            .FirstOrDefaultAsync(m => m.FollowUpId == followupid);
        if (followup == null)
        {
            return NotFound();
        }

        return View(followup);
    }

    // GET: FOLLOWUPS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: FOLLOWUPS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("FollowUpId,CustomerName,FollowUpDate,FollowUpType,Remarks,Status")] FollowUp followup)
    {
        if (ModelState.IsValid)
        {
            _context.Add(followup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(followup);
    }

    // GET: FOLLOWUPS/Edit/5
    public async Task<IActionResult> Edit(int? followupid)
    {
        if (followupid == null)
        {
            return NotFound();
        }

        var followup = await _context.FollowUps.FindAsync(followupid);
        if (followup == null)
        {
            return NotFound();
        }
        return View(followup);
    }

    // POST: FOLLOWUPS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? followupid, [Bind("FollowUpId,CustomerName,FollowUpDate,FollowUpType,Remarks,Status")] FollowUp followup)
    {
        if (followupid != followup.FollowUpId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(followup);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FollowUpExists(followup.FollowUpId))
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
        return View(followup);
    }

    // GET: FOLLOWUPS/Delete/5
    public async Task<IActionResult> Delete(int? followupid)
    {
        if (followupid == null)
        {
            return NotFound();
        }

        var followup = await _context.FollowUps
            .FirstOrDefaultAsync(m => m.FollowUpId == followupid);
        if (followup == null)
        {
            return NotFound();
        }

        return View(followup);
    }

    // POST: FOLLOWUPS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? followupid)
    {
        var followup = await _context.FollowUps.FindAsync(followupid);
        if (followup != null)
        {
            _context.FollowUps.Remove(followup);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool FollowUpExists(int? followupid)
    {
        return _context.FollowUps.Any(e => e.FollowUpId == followupid);
    }
}
