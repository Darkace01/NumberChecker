using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NumberChecker.Models;

namespace NumberChecker.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Calculator()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calculator(string firstnumber, string secondnumber)
        {
            if (firstnumber != null || secondnumber != null)
            {
                double sqfirst = Math.Sqrt(int.Parse(firstnumber));
                double sqsecond = Math.Sqrt(int.Parse(secondnumber));
                if (firstnumber.Contains("-") || secondnumber.Contains("-"))
                {
                    ViewBag.Error = "Number is a negative number";
                }
                else if (sqfirst == sqsecond)
                {
                    ViewBag.Check = "The square root of both numbers are the same";
                }
                else
                {
                    ViewBag.First = sqfirst;
                    ViewBag.Second = sqsecond;
                    ViewBag.F = firstnumber;
                    ViewBag.S = secondnumber;
                }
            }
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
