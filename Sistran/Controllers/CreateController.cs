using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaSistran.Servicios.Services;
using Sistran.Models;

namespace Sistran.Controllers
{
    public class CreateController : Controller
    {
        private readonly IPersonService _personService;

        public CreateController(IPersonService personService)
        {
            _personService = personService;
        }

        // GET: CreateController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CreateController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Persona persona)
        {
            try
            {
                var existingPerson = await _personService.GetByIdAsync(persona.Identificacion);

                if (existingPerson != null)
                {
                    ModelState.AddModelError("Identificacion", "Ya existe una persona con esta identificación.");
                    return View(persona);
                }

                if (ModelState.IsValid)
                {
                    bool success = await _personService.InsertAsync(persona);
                    if (success)
                    {
                        return Redirect("/");
                    }
                }

                return View(persona);
            }
            catch
            {
                return View(persona);
            }
        }

        // GET: CreateController/Index
        public async Task<ActionResult> Index()
        {
            //var personas = await _personService.GetAllAsync();
            //return View(personas);
            return RedirectToAction(nameof(Create));
        }
    }
}
