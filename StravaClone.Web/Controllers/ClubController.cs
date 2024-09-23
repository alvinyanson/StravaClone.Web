using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StravaClone.Web.Data;

namespace StravaClone.Web.Controllers
{
    public class ClubController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClubController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var clubs = await _context.Clubs.ToListAsync();

            return View(clubs);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var club = await _context.Clubs.Include(a => a.Address).FirstOrDefaultAsync(c => c.Id == id);

            return View(club);
        }
    }
}
