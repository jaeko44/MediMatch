using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediMatchRMIT.Models;

namespace MediMatchRMIT.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.CurrentPage = "Index";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "MediMatch Contact Page.";
            ViewBag.CurrentPage = "Contact";
            return View();
        }
        public IActionResult App()
        {
            ViewData["Message"] = "MediMatch Application Page.";
            ViewBag.CurrentPage = "Application";
            return View();
        }
        public IActionResult Privacy()
        {
            ViewData["Message"] = "MediMatch Privacy Page.";
            ViewBag.CurrentPage = "Privacy";
            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
