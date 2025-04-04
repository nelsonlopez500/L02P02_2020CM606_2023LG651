using L02P02_2020CM606_2023LG651.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace L02P02_2020CM606_2023LG651.Controllers
{
    public class LibrosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LibrosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Libros/PorAutor/5
        public async Task<IActionResult> PorAutor(int id)
        {
            var autor = await _context.autores.FindAsync(id);
            if (autor == null)
            {
                return NotFound();
            }

            ViewBag.Autor = autor;

            var libros = await _context.libros
                .Include(l => l.Autor)
                .Include(l => l.Categoria)
                .Where(l => l.id_autor == id)
                .ToListAsync();

            return View(libros);
        }
    }
}