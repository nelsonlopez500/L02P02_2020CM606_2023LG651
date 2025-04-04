using L02P02_2020CM606_2023LG651.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace L02P02_2020CM606_2023LG651.Controllers
{
    public class AutoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AutoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Autores
        public async Task<IActionResult> Index()
        {
            var autores = await _context.autores.ToListAsync();
            return View(autores);
        }
    }
}