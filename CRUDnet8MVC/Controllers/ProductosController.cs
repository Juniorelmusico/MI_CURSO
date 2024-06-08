using CRUDnet8MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDnet8MVC.Controllers
{
    public class ProductosController : Controller
    {
        public readonly ApplicationDbContext _contexto;

        public ProductosController(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        public IActionResult Index()
        {
            List<Producto> listaProductos = _contexto.Producto.ToList();
            return View(listaProductos);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Producto producto)
        {
            if (ModelState.IsValid)
            {
                _contexto.Producto.Add(producto);
                _contexto.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return View();
            }

            var producto = _contexto.Producto.FirstOrDefault(c => c.Id == id);
            return View(producto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Producto producto)
        {
            if (ModelState.IsValid)
            {
                _contexto.Producto.Update(producto);
                _contexto.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        [HttpGet]
        public IActionResult Borrar(int? id)
        {
            var producto = _contexto.Producto.FirstOrDefault(c => c.Id == id);
            _contexto.Producto.Remove(producto);
            _contexto.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
