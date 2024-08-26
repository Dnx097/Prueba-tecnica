using System;
using System.Collections.Generic;

namespace SISTRAN.CAD.Models;

public partial class Persona
{
    public int IdPersona { get; set; }

    public int Identificacion { get; set; }

    public string? Nombres { get; set; }

    public string? Apellidos { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public long? Celular { get; set; }

    public long? TelAlternativo { get; set; }

    public string? Correo { get; set; }

    public string? CorreoAlt { get; set; }

    public string? Direccion { get; set; }

    public string? DireccionAlt { get; set; }
}
