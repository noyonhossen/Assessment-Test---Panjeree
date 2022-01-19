using CardApp.Extensions;
using CardApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CardApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            IncreaseCount();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public void IncreaseCount()
        {
            var count =  HttpContext.Session.GetComplexData<int>("ItemCount");
            count++;
            HttpContext.Session.SetComplexData("ItemCount",count);
            ViewBag.items = count;
        }

        public void DecreaseCount()
        {
            var count = HttpContext.Session.GetComplexData<int>("ItemCount");
            count--;
            HttpContext.Session.SetComplexData("ItemCount", count);
            ViewBag.items = count;
        }
    }
}
