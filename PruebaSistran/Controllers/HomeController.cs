using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaSistran.Models;
using PruebaSistran.Servicios.Services;
using SISTRAN.CAD.Models;
using System.Diagnostics;
using System.Globalization;

namespace PruebaSistran.Controllers
{
    public class HomeController : Controller
    {

        private readonly IPeopleRegister _register;

        public HomeController(IPeopleRegister register)
        {
            _register = register;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            try
            {
                var lista = await _register.GetAll();

        

                return StatusCode(StatusCodes.Status200OK, lista);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
          
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PersonsDTO obj)
        {
            // Validación de entrada
            if (obj == null)
            {
                return BadRequest("Los datos de la persona son requeridos.");
            }

            // Validación de campos obligatorios
            // Validación de campos obligatorios
            if (obj.Identificacion == null)
            {
                return BadRequest("El campo Identificación es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(obj.Nombres))
            {
                return BadRequest("El campo Nombres es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(obj.Apellidos))
            {
                return BadRequest("El campo Apellidos es obligatorio.");
            }

            // Usar un método de extensión o una función auxiliar para la conversión de string a long?
            var persona = new Persona
            {
                Identificacion = obj.Identificacion,
                Nombres = obj.Nombres,
                Apellidos = obj.Apellidos,
                FechaNacimiento = obj.FechaNacimiento,
                Celular = long.Parse(obj.Celular),
                TelAlternativo = long.Parse(obj.TelAlternativo),
                Correo = obj.Correo,
                CorreoAlt = obj.CorreoAlt,
                Direccion = obj.Direccion,
                DireccionAlt = obj.DireccionAlt
            };

            try
            {
                bool res = await _register.Insert(persona);
                return Ok(new { valor = res });
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar la solicitud.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PersonsDTO obj)
        {
            Persona persona = new Persona()
            {
                Identificacion = obj.Identificacion,
                Nombres = obj.Nombres,
                Apellidos = obj.Apellidos,
                FechaNacimiento = obj.FechaNacimiento,
                Celular = !string.IsNullOrEmpty(obj.Celular) ? long.Parse(obj.Celular) : (long?)null,
                TelAlternativo = !string.IsNullOrEmpty(obj.TelAlternativo) ? long.Parse(obj.TelAlternativo) : (long?)null,
                Correo = obj.Correo,
                CorreoAlt = obj.CorreoAlt,
                Direccion = obj.Direccion,
                DireccionAlt = obj.DireccionAlt
            };
            bool res = await _register.Update(persona);
            return StatusCode(StatusCodes.Status200OK, new { valor = res });
        }


        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("El ID proporcionado no es válido.");
            }

            var persona = await _register.GetById(id);

            if (persona == null)
            {
                return NotFound($"No se encontró ninguna persona con el ID {id}.");
            }

            return Ok(new { valor = persona });
        }



        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            bool res = await _register.Delete(id);
            return StatusCode(StatusCodes.Status200OK, new { valor = res });
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
