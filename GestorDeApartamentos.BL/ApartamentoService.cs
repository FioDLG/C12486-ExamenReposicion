using System;
using System.Collections.Generic;
using System.Linq;
using GestorDeApartamentos.DA;
using GestorDeApartamentos.Model;

namespace GestorDeApartamentos.BL
{
    public class ApartamentosService
    {
        public decimal CalcularDeposito(int meses, decimal precioPorMes)
        {
            if (meses < 12) return precioPorMes;
            if (meses < 24) return precioPorMes * 0.75m;
            return precioPorMes * 0.50m;
        }
        public void Alquilar(Apartamento apartamento,
                             string identificacionInquilino,
                             string nombreInquilino,
                             DateTime fechaInicio,
                             int cantidadMeses)
        {
            apartamento.Estado = (int)EstadoApartamento.Alquilado;
            apartamento.IdentificacionInquilino = identificacionInquilino;
            apartamento.NombreInquilino = nombreInquilino;
            apartamento.FechaInicioAlquiler = fechaInicio;
            apartamento.CantidadDeMesesAlquiler = cantidadMeses;

            
            apartamento.DepositoDeGarantia = apartamento.PrecioPorMes * cantidadMeses;
        }

 
        public void Devolver(Apartamento apartamento)
        {
            apartamento.Estado = (int)EstadoApartamento.Disponible;
            apartamento.IdentificacionInquilino = null;
            apartamento.NombreInquilino = null;
            apartamento.FechaInicioAlquiler = null;
            apartamento.CantidadDeMesesAlquiler = null;
            apartamento.DepositoDeGarantia = null;
        }
    }
}
