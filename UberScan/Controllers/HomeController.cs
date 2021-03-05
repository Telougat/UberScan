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
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private UberScan.Shared.UberScan db;

        public HomeController(ILogger<HomeController> logger, UberScan.Shared.UberScan injectedContext)
        {
            _logger = logger;
            db = injectedContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        //[Route("/Home/Manga/{search}")]
        public IActionResult Manga(string search)
        { //All
            //if(search == "All")
            //{
                var Mangas = db.Mangas.ToArray();
                var model = new MangaViewModel{
                    Mangas = Mangas
                };
                return View(model);
            //}
            /*else {
                var Mangas = db.Mangas.ToArray().Where(m => m.MangaNameLat == search);
                var model = new MangaViewModel{
                    Mangas = Mangas
                };
                return View(model);
            }*/
            
        }

/*
        [Route("/Home/Manga/{search}")]
        public IActionResult FilterManga(string search)
        {
            Console.WriteLine(search);
            //Console.WriteLine(textFilter);
            Console.WriteLine(ViewData["KeyFilter"]);
            var listeMangas = db.Mangas.ToArray();
            var model = new MangaViewModel{
                Mangas = listeMangas
            };

            switch(ViewData["KeyFilter"])
            {
                case "nom" : 
                    var MangasByName = db.Mangas.ToArray();
                    model = new MangaViewModel{
                        Mangas = MangasByName
                    };
                    break;
                case "auteur":
                    var MangasByAuthor = db.Mangas.ToArray();
                    model = new MangaViewModel{
                        Mangas = MangasByAuthor
                    };
                    break;
                case "genre" :
                    var MangasByGenre = db.Mangas.ToArray();
                    model = new MangaViewModel{
                        Mangas = MangasByGenre
                    };
                    break;
            }

            return View(model);
        }*/

        [Route("/Home/Manga/{id}")]
        public IActionResult Volume(int? id)
        {
            var Manga = db.Mangas.Where(m => m.MangaID == id).SingleOrDefault();
            var Volumes = db.Volumes.Where(v => v.MangaId == id).ToArray();
            var model = new VolumeViewModel{
                Manga = Manga,
                Volumes = Volumes
            };
            return View(model);
        }

        [Route("/Home/Volume/{id}")]
        public IActionResult Scan(int? id)
        {
            var Volume = db.Volumes.Where(v => v.VolumeId == id).SingleOrDefault();
            var Manga = db.Mangas.Where(m => m.MangaID == Volume.MangaId).SingleOrDefault();
            var model = new ScanViewModel{
                MangaVolume = Manga,
                Volume = Volume
            };
            return View(model);
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
