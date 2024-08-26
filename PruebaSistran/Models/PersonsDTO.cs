using System.ComponentModel.DataAnnotations;

namespace PruebaSistran.Models
{
    public class PersonsDTO
    {
        public int IdPersona { get; set; }

        public int Identificacion { get; set; }

        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public DateTime? FechaNacimiento { get; set; }

        public string Celular { get; set; }

        public string TelAlternativo { get; set; }

        public string Correo { get; set; }

        public string CorreoAlt { get; set; }

        public string Direccion { get; set; }

        public string DireccionAlt { get; set; }
    }
}
