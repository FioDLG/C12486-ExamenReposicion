using System;
using System.Collections.Generic;
using System.Text;

namespace GestorDeApartamentos.Model
{
    public class AlquilerDetalleDTO
    {
        public string Nombre { get; set; }
        public int Estado { get; set; }
        public int NumeroPiso { get; set; }
        public string NombreInquilino { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public decimal MontoDeposito { get; set; }
    }
}
