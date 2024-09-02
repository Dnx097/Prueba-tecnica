using Microsoft.AspNetCore.Mvc;
using PruebaSistran.Servicios.Services;
using Sistran.Models;
using System.Diagnostics;

namespace Sistran.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPersonService _personService;

        public HomeController(ILogger<HomeController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        public async Task<IActionResult> Index()
        {
            var personas = await _personService.GetAllAsync();
            return View(personas);
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

        // POST: HomeController/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                bool success = await _personService.DeleteAsync(id);
                if (success)
                {
                    return RedirectToAction(nameof(Index));
                }

                return RedirectToAction(nameof(Index)); 
            }
            catch
            {
                return RedirectToAction(nameof(Index)); 
            }
        }

    }
}
