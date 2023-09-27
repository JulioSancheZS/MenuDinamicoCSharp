using System;
using System.Collections.Generic;

namespace MenuDinamicoAPI.Models;

public partial class ItemRol
{
    public int IdItemRol { get; set; }

    public int IdItemMenu { get; set; }

    public int IdRol { get; set; }

    public virtual ItemMenu IdItemMenuNavigation { get; set; } = null!;

    public virtual Rol IdRolNavigation { get; set; } = null!;
}
