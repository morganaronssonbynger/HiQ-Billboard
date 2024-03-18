using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Billboard.Models;

namespace Billboard.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var events = new DAL().GetJson().Result;
        return View(events);
    } 

    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult HiQ()
    {
        return View();
    }

    public IActionResult Birthday()
    {
        return View();
    }
    public IActionResult ManyBirthday()
    {
        return View();
    }



    public IActionResult Corona()
    {
        var events = new DAL().GetJson().Result;
        return View(events);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

