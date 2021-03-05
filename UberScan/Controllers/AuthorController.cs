using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UberScan.Models;
using UberScan.Shared;

namespace UberScan.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ILogger<AuthorController> _logger;
        private UberScan.Shared.UberScan db;

        public AuthorController(ILogger<AuthorController> logger, UberScan.Shared.UberScan injectedContext)
        {
            _logger = logger;
            db = injectedContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string firstName, string lastName, DateTime birthdate, string nationality,
            string description)
        {
            db.Add(new Author()
            {
                AuthorID = db.Authors.Select(a => a.AuthorID).Max() + 1,
                AuthorFirstName = firstName,
                AuthorLastName = lastName,
                AuthorDescription = description,
                Nationality = nationality,
                BirthDate = birthdate.Date
            });
            db.SaveChanges();
            return View();
        }

        public IActionResult ViewPdf()
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