namespace MenuDinamicoAPI.DTO
{
    public class MenuItemDTO
    {
        public int IdItemMenu { get; set; }
        public int? IdItemMenuPadre { get; set; }
        public string Ruta { get; set; }
        public string Texto { get; set; }
        public bool Visible { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool EsActivo { get; set; }
        public List<MenuItemDTO> Submenu { get; set; }
    }
}
