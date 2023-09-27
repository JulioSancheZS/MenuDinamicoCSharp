using System;
using System.Collections.Generic;

namespace MenuDinamicoAPI.Models;

public partial class Rol
{
    public int IdRol { get; set; }

    public string? NombreRol { get; set; }

    public virtual ICollection<ItemRol> ItemRols { get; set; } = new List<ItemRol>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
