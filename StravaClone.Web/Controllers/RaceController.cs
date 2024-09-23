using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StravaClone.Web.Data;

namespace StravaClone.Web.Controllers
{
    public class RaceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RaceController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var races = await _context.Races.ToListAsync();

            return View(races);
        }
    }
}
