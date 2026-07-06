using GestorDeApartamentos.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GestorDeApartamentos.DA
{
    public class ApartamentosRepository
    {
        private readonly ExamenDbContext _context;

        public ApartamentosRepository(ExamenDbContext context)
        {
            _context = context;
        }

        
        public IEnumerable<Apartamento> ObtenerTodos()
        {
            return _context.Apartamentos.ToList();
        }

        
        public void Agregar(Apartamento apartamento)
        {
            _context.Apartamentos.Add(apartamento);
            _context.SaveChanges();
        }

       
        public void Actualizar(Apartamento apartamento)
        {
            _context.Apartamentos.Update(apartamento);
            _context.SaveChanges();
        }

        
        public Apartamento? ObtenerPorId(int id)
        {
            return _context.Apartamentos.Find(id);
        }
    }
}
