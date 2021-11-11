using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProfileManager.Models;
using ProfileManager.Repository;
using ProfileManager.ViewModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ProfileManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProfileRepository _repo;


        public HomeController(ILogger<HomeController> logger, IProfileRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterDTO model)
        {
            var response = await _repo.Register(model);

            if (!response)
                return View(model);

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
