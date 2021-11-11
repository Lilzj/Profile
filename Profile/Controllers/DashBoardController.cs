using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProfileManager.Models;
using ProfileManager.Repository;
using System.Threading.Tasks;

namespace ProfileManager.Controllers
{
    public class DashBoardController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProfileRepository _repo;

        public DashBoardController(ILogger<HomeController> logger, IProfileRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public async  Task<IActionResult> Index(User model)
        {

            var user = await _repo.GetProfile(model.Email);

            if (user == null)
            {
                return View();
            }

            if (user.TransactionNumber != model.TransactionNumber)
            {
                return View();
            }

            return View(user);
        }
    }
}
