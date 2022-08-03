using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FirstCoreSolution.Models;

namespace FirstCoreSolution.Controllers;

public class HomeController : Controller
{
    private AppDbContext ctx { get; set; }=null!;
    public HomeController(AppDbContext _ctx){
        ctx=_ctx;
    }

    public IActionResult Index(){
        return View();
    }

    public IActionResult FAQ(){
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
