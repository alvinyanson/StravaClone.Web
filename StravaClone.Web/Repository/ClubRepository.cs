using Microsoft.EntityFrameworkCore;
using StravaClone.Web.Data;
using StravaClone.Web.Interfaces;
using StravaClone.Web.Models;

namespace StravaClone.Web.Repository
{
    public class ClubRepository : IClubRepository
    {
        private readonly ApplicationDbContext _context;

        public ClubRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Club club)
        {
            _context.Add(club);

            return Save();
        }

        public bool Delete(Club club)
        {
            _context.Remove(club);

            return Save();
        }

        public async Task<IEnumerable<Club>> GetAllAsync()
        {
            return await _context.Clubs.Include(c => c.Address).ToListAsync();
        }

        public async Task<Club> GetByIdAsync(int id)
        {
            var club = await _context.Clubs.Include(c => c.Address).FirstOrDefaultAsync(x => x.Id == id);

            return club;
        }

        public async Task<Club> GetByIdAsyncNoTracking(int id)
        {
            var club = await _context.Clubs.Include(c => c.Address).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            return club;
        }

        public async Task<IEnumerable<Club>> GetClubsByCityAsync(string city)
        {
            var club = await _context.Clubs.Where(x => x.Address.City.Contains(city)).Include(c => c.Address).ToListAsync();

            return club;
        }

        public bool Save()
        {
            var save = _context.SaveChanges();

            return save > 0;
        }

        public bool Update(Club club)
        {
            _context.Update(club);

            return Save();
        }
    }
}
