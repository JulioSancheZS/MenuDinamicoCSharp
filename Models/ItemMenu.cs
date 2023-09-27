using System;
using System.Collections.Generic;

namespace MenuDinamicoAPI.Models;

public partial class ItemMenu
{
    public int IdItemMenu { get; set; }

    public int? IdItemMenuPadre { get; set; }

    public string Ruta { get; set; } = null!;

    public string Texto { get; set; } = null!;

    public bool? Visible { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public bool? EsActivo { get; set; }

    public virtual ItemMenu? IdItemMenuPadreNavigation { get; set; }

    public virtual ICollection<ItemMenu> InverseIdItemMenuPadreNavigation { get; set; } = new List<ItemMenu>();

    public virtual ICollection<ItemRol> ItemRols { get; set; } = new List<ItemRol>();
}
