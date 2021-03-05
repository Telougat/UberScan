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

        public IActionResult Manga()
        {
            var Mangas = db.Mangas.ToArray();
            var model = new MangaViewModel{
                Mangas = Mangas
            };
            return View(model);
        }

        [Route("/Home/Manga/{id}")]
        public IActionResult Volume(int? id)
        {
            var Manga = db.Mangas.Where(m => m.MangaID == id).SingleOrDefault();
            var Volumes = db.Volumes.Where(v => v.MangaId == id).ToArray();
            var Publisher = db.Publishers.Where(p => p.PublisherID == Manga.PublisherID).SingleOrDefault();
            var Author = db.Authors.Where(a => a.AuthorID == Manga.AuthorID).SingleOrDefault();
            var Translator = db.FrTranslators.Where(ft => ft.TranlatorID == Manga.TranlatorID).SingleOrDefault();
            var Category = db.Categories.Where(c => c.CategoryID == Manga.CategoryID).SingleOrDefault();
            var model = new VolumeViewModel{
                Manga = Manga,
                Publisher = Publisher,
                Author = Author,
                Translator = Translator,
                Category = Category,
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
