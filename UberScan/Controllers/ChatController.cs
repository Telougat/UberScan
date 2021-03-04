using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UberScan.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}