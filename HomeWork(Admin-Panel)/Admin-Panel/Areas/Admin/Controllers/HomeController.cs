using Microsoft.AspNetCore.Mvc;

namespace Admin_Panel.Areas.Admin.Controllers;
[Area("Admin")]
public class HomeController : Controller
{
    public IActionResult Index() => View();
}