using System.ComponentModel.DataAnnotations;

namespace GestorDeApartamentos.Model
{
    
        public class Apartamento
        {
            public int Id { get; set; }
            public string Nombre { get; set; } = string.Empty;
            public string Descripcion { get; set; } = string.Empty;
            public int Estado { get; set; } // 1 = Disponible, 2 = Alquilado
            public int NumeroDePiso { get; set; }
            public decimal PrecioPorMes { get; set; }
            public string? IdentificacionInquilino { get; set; }
            public string? NombreInquilino { get; set; }
            public DateTime? FechaInicioAlquiler { get; set; }
            public int? CantidadDeMesesAlquiler { get; set; }
            public decimal? DepositoDeGarantia { get; set; }
        }
    
}
