using L02P02_2020CM606_2023LG651.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
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

        // POST: Comentarios/GuardarComentario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GuardarComentario(int idLibro, string usuario, string comentarioTexto)
        {
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(comentarioTexto))
            {
                return RedirectToAction("PorLibro", new { id = idLibro });
            }

            var nuevoComentario = new comentarios_libros
            {
                id_libro = idLibro,
                usuario = usuario,
                comentarios = comentarioTexto,
                created_at = DateTime.Now
            };

            _context.comentarios_libros.Add(nuevoComentario);
            await _context.SaveChangesAsync();

            return RedirectToAction("Confirmacion", new { id = nuevoComentario.id });
        }

        // GET: Comentarios/Confirmacion/5
        public async Task<IActionResult> Confirmacion(int id)
        {
            var comentario = await _context.comentarios_libros
                .Include(c => c.Libro)
                .ThenInclude(l => l.Autor)
                .Include(c => c.Libro.Categoria)
                .FirstOrDefaultAsync(c => c.id == id);

            if (comentario == null)
            {
                return NotFound();
            }

            return View(comentario);
        }
    }
}