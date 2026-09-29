
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Acxiom_CRM.Models;
using Acxiom_CRM.Data;

public class OpportunitiesController : Controller
{
    private readonly ApplicationDbContext _context;

    public OpportunitiesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: OPPORTUNITYS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Opportunities.ToListAsync());
    }

    // GET: OPPORTUNITYS/Details/5
    public async Task<IActionResult> Details(int? opportunityid)
    {
        if (opportunityid == null)
        {
            return NotFound();
        }

        var opportunity = await _context.Opportunities
            .FirstOrDefaultAsync(m => m.OpportunityId == opportunityid);
        if (opportunity == null)
        {
            return NotFound();
        }

        return View(opportunity);
    }

    // GET: OPPORTUNITYS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: OPPORTUNITYS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("OpportunityId,OpportunityName,Amount,Probability,SalesStage,Status,ExpectedCloseDate,CreatedDate")] Opportunity opportunity)
    {
        if (ModelState.IsValid)
        {
            _context.Add(opportunity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(opportunity);
    }

    // GET: OPPORTUNITYS/Edit/5
    public async Task<IActionResult> Edit(int? opportunityid)
    {
        if (opportunityid == null)
        {
            return NotFound();
        }

        var opportunity = await _context.Opportunities.FindAsync(opportunityid);
        if (opportunity == null)
        {
            return NotFound();
        }
        return View(opportunity);
    }

    // POST: OPPORTUNITYS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? opportunityid, [Bind("OpportunityId,OpportunityName,Amount,Probability,SalesStage,Status,ExpectedCloseDate,CreatedDate")] Opportunity opportunity)
    {
        if (opportunityid != opportunity.OpportunityId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(opportunity);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OpportunityExists(opportunity.OpportunityId))
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
        return View(opportunity);
    }

    // GET: OPPORTUNITYS/Delete/5
    public async Task<IActionResult> Delete(int? opportunityid)
    {
        if (opportunityid == null)
        {
            return NotFound();
        }

        var opportunity = await _context.Opportunities
            .FirstOrDefaultAsync(m => m.OpportunityId == opportunityid);
        if (opportunity == null)
        {
            return NotFound();
        }

        return View(opportunity);
    }

    // POST: OPPORTUNITYS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? opportunityid)
    {
        var opportunity = await _context.Opportunities.FindAsync(opportunityid);
        if (opportunity != null)
        {
            _context.Opportunities.Remove(opportunity);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool OpportunityExists(int? opportunityid)
    {
        return _context.Opportunities.Any(e => e.OpportunityId == opportunityid);
    }
}
