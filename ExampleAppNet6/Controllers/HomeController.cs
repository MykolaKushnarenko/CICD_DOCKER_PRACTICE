using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ExampleAppNet6.Models;

namespace ExampleAppNet6.Controllers;

public class HomeController : Controller
{
    private IRepository repository;
    private string message;

    public HomeController(IRepository repo, IConfiguration config)
    {
        repository = repo;
        message =  $"Essential Docker ({config["HOSTNAME"]})";
    }
    
    public IActionResult Index()
    {
        ViewBag.Message = message;
        return View(repository.Products);
    }
}