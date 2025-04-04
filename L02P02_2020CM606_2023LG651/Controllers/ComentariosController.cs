using L02P02_2020CM606_2023LG651.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace L02P02_2020CM606_2023LG651.Controllers
{
    public class ComentariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ComentariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Comentarios/PorLibro/5
        public async Task<IActionResult> PorLibro(int id)
        {
            var libro = await _context.libros
                .Include(l => l.Autor)
                .Include(l => l.Categoria)
                .FirstOrDefaultAsync(l => l.id == id);

            if (libro == null)
            {
                return NotFound();
            }

            ViewBag.Libro = libro;

            var comentarios = await _context.comentarios_libros
                .Where(c => c.id_libro == id)
                .OrderByDescending(c => c.created_at)
                .ToListAsync();

            return View(comentarios);
        }
    }
}