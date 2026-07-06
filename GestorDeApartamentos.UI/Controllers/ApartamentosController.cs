using Microsoft.AspNetCore.Mvc;
using GestorDeApartamentos.BL;
using GestorDeApartamentos.DA;
using GestorDeApartamentos.Model;




namespace GestorDeApartamentos.UI.Controllers
{
    public class ApartamentosController : Controller
    {
        private readonly ApartamentosRepository _repositorio;
        private readonly ApartamentosService _servicio;

        public ApartamentosController(ApartamentosRepository repositorio, ApartamentosService servicio)
        {
            _repositorio = repositorio;
            _servicio = servicio;
        }

        public IActionResult Index(string? filtroNombre)
        {
            var lista = _repositorio.ObtenerTodos();

            if (!string.IsNullOrWhiteSpace(filtroNombre))
                lista = lista.Where(a => a.Nombre.Contains(filtroNombre));

            return View(lista);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Apartamento apartamento)
        {
            if (!ModelState.IsValid)
                return View(apartamento);

            apartamento.Estado = (int)EstadoApartamento.Disponible;
            _repositorio.Agregar(apartamento);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var apto = _repositorio.ObtenerPorId(id);
            return View(apto);
        }

        [HttpPost]
        public IActionResult Edit(Apartamento apartamento)
        {
            if (!ModelState.IsValid)
                return View(apartamento);

            _repositorio.Actualizar(apartamento);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalle(int id)
        {
            var apto = _repositorio.ObtenerPorId(id);
            return View(apto);
        }

        public IActionResult Disponibles()
        {
            var lista = _repositorio.ObtenerTodos()
                                    .Where(a => a.Estado == (int)EstadoApartamento.Disponible);

            return View(lista);
        }



        public IActionResult Alquilados(string? filtroInquilino)
        {
            var lista = _repositorio.ObtenerTodos()
                                    .Where(a => a.Estado == (int)EstadoApartamento.Alquilado);

            if (!string.IsNullOrWhiteSpace(filtroInquilino))
                lista = lista.Where(a => a.NombreInquilino.Contains(filtroInquilino));

            return View(lista);
        }


        [HttpGet]
        public IActionResult Alquilar(int id)
        {
            var apartamento = _repositorio.ObtenerPorId(id);
            return View(apartamento);
        }

        [HttpPost]
        public IActionResult Alquilar(Apartamento apartamento)
        {
            var apto = _repositorio.ObtenerPorId(apartamento.Id);

            if (apto != null)
            {
                _servicio.Alquilar(apto,
                    apartamento.IdentificacionInquilino,
                    apartamento.NombreInquilino,
                    apartamento.FechaInicioAlquiler.Value,
                    apartamento.CantidadDeMesesAlquiler.Value);

                _repositorio.Actualizar(apto);
            }

            return RedirectToAction("Alquilados");

        }

        [HttpGet]
        public IActionResult Devolver(int id)
        {
            var apto = _repositorio.ObtenerPorId(id);
            return View(apto);
        }

        [HttpPost]
        public IActionResult Devolver(Apartamento apartamento)
        {
            var apto = _repositorio.ObtenerPorId(apartamento.Id);

            if (apto != null)
            {
                _servicio.Devolver(apto);
                _repositorio.Actualizar(apto);
            }

            return RedirectToAction(nameof(Disponibles));
        }

    }
}
