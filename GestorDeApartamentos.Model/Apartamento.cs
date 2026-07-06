using System.ComponentModel.DataAnnotations;

namespace GestorDeApartamentos.Model
{
    public class Apartamento
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [Display(Name = "Nombre del Apartamento")]
        public string Nombre { get; set; }

        [Display(Name = "Descripción")]
        public string? Descripcion { get; set; }

        [Range(1, 50, ErrorMessage = "El piso debe estar entre 1 y 50")]
        [Display(Name = "Número de Piso")]
        public int NumeroDePiso { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
        [Display(Name = "Precio por Mes")]
        public decimal PrecioPorMes { get; set; }

        public int Estado { get; set; }

        [Display(Name = "Cédula del Inquilino")]
        public string? IdentificacionInquilino { get; set; }

        [Display(Name = "Nombre del Inquilino")]
        public string? NombreInquilino { get; set; }

        [Display(Name = "Fecha de Inicio del Alquiler")]
        public DateTime? FechaInicioAlquiler { get; set; }

        [Display(Name = "Cantidad de Meses de Alquiler")]
        public int? CantidadDeMesesAlquiler { get; set; }

        [Display(Name = "Depósito de Garantía")]
        public decimal? DepositoDeGarantia { get; set; }
    }
}
