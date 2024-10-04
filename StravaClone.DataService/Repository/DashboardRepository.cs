using Microsoft.EntityFrameworkCore;
using StravaClone.DataService.Data;
using StravaClone.DataService.Interfaces;
using StravaClone.Entities.Models;

namespace StravaClone.DataService.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly ApplicationDbContext _context;

        public DashboardRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Club>> GetAllUserClubs(string userId)
        {
            var userClubs = _context.Clubs.Where(x => x.AppUser.Id == userId).Include(x => x.Address).ToList();

            return userClubs.ToList();
        }

        public async Task<List<Race>> GetAllUserRaces(string userId)
        {
            var userRaces = _context.Races.Where(x => x.AppUser.Id == userId).Include(x => x.Address).ToList();

            return userRaces.ToList();
        }

        public async Task<AppUser> GetUserById(string id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<AppUser> GetByIdNoTracking(string id)
        {
            return await _context.Users.Where(u => u.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public bool Update(AppUser user)
        {
            _context.Users.Update(user);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }
    }
}
