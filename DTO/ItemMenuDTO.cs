namespace MenuDinamicoAPI.DTO
{
    public class ItemMenuDTO
    {
        public int IdItemMenu { get; set; }

        public int? IdItemMenuPadre { get; set; }

        public string Ruta { get; set; } = null!;

        public string Texto { get; set; } = null!;

        public bool? Visible { get; set; }

        public DateTime? FechaRegistro { get; set; }

        public bool? EsActivo { get; set; }
    }
}
