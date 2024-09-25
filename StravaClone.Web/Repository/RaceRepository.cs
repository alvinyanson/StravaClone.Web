using Microsoft.EntityFrameworkCore;
using StravaClone.Web.Data;
using StravaClone.Web.Interfaces;
using StravaClone.Web.Models;

namespace StravaClone.Web.Repository
{
    public class RaceRepository : IRaceRepository
    {
        private readonly ApplicationDbContext _context;

        public RaceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Race race)
        {
            _context.Add(race);

            return Save();
        }

        public bool Delete(Race race)
        {
            _context.Remove(race);

            return Save();
        }

        public async Task<IEnumerable<Race>> GetAllAsync()
        {
            return await _context.Races.Include(c => c.Address).ToListAsync();
        }

        public async Task<Race> GetByIdAsync(int id)
        {
            var race = await _context.Races.Include(r => r.Address).FirstOrDefaultAsync(x => x.Id == id);

            return race;
        }

        public async Task<Race> GetByIdAsyncNoTracking(int id)
        {
            var race = await _context.Races.Include(c => c.Address).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            return race;
        }

        public async Task<IEnumerable<Club>> GetRacesByCityAsync(string city)
        {
            var club = await _context.Clubs.Where(x => x.Address.City.Contains(city)).Include(c => c.Address).ToListAsync();

            return club;
        }

        public bool Save()
        {
            var save = _context.SaveChanges();

            return save > 0;
        }

        public bool Update(Race race)
        {
            _context.Update(race);

            return Save();
        }
    }
}
