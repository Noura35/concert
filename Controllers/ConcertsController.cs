namespace concerts.Controllers;

using concerts.Data;
using concerts.Models;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;

public class ConcertsController : Controller
{
    private readonly FestivalContext _context;

    public ConcertsController(FestivalContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("Concerts")]
    [Route("Concerts/Index")]
    public async Task<IActionResult> Index()
    {
        var concerts = await _context.Concerts.ToListAsync();
        return View(concerts);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Concert concert)
    {
        if (ModelState.IsValid)
        {
            _context.Concerts.Add(concert);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(concert);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var concert = await _context.Concerts.FindAsync(id);
        if (concert == null)
        {
            return NotFound();
        }
        return View(concert);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Concert concert)
    {
        if (ModelState.IsValid)
        {
            _context.Concerts.Update(concert);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(concert);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var concert = await _context.Concerts.FindAsync(id);
        if (concert == null)
        {
            return NotFound();
        }
        return View(concert);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var concert = await _context.Concerts.FindAsync(id);
        if (concert != null)
        {
            _context.Concerts.Remove(concert);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var concert = await _context.Concerts.FindAsync(id);
        if (concert == null)
        {
            return NotFound();
        }
        return View(concert);
    }
}
