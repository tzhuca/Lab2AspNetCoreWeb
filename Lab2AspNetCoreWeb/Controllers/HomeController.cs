using Lab2AspNetCoreWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2AspNetCoreWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //Tony  inject config
        public IConfiguration Config { get; }
        public HomeController(IConfiguration config, ILogger<HomeController> logger)
        {
            _logger = logger;
            Config = config;

        }

        public IActionResult Index()
        {
            ViewBag.Setting = Config["Setting"].ToString();
            ViewBag.Log=Config["Logging:LogLevel:Default"].ToString();
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
    }
}
