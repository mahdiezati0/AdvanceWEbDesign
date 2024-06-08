using Admin_Panel.Areas.Admin.Models;
using Admin_Panel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Admin_Panel.Areas.Admin.Controllers;
[Area("Admin")]
public class CustomerController(MyContext context) : Controller
{
    private readonly MyContext _context = context;
    public async Task<IActionResult> Index(int page = 1, int size = 10)
    {
        var customers = await _context.Customers
            .Skip((page - 1) * size).Take(size).ToListAsync(HttpContext.RequestAborted);
        return View(customers);
    }
    public async Task<IActionResult> Details(int? id)
    {
        var customer = await _context.Customers
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.CustomerId == id, HttpContext.RequestAborted);
        if (customer is null)
        {
            return BadRequest();
        }
        return View(customer);
    }
    public IActionResult Create() => View();
    [HttpPost]
    public async Task<IActionResult> Create(CustomerViewModel model)
    {
        if(!ModelState.IsValid)
        {
            return View(model);
        }
        _context.Customers.Add(model);
        await _context.SaveChangesAsync(HttpContext.RequestAborted);
        return RedirectToAction(nameof(Details), new {id=model.CustomerId });
    }
}