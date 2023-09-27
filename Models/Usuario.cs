using System;
using System.Collections.Generic;

namespace MenuDinamicoAPI.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public int IdRol { get; set; }

    public string Usuario1 { get; set; } = null!;

    public string Pass { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public DateTime? FechaRegistro { get; set; }

    public bool? EsActivo { get; set; }

    public virtual Rol IdRolNavigation { get; set; } = null!;
}
