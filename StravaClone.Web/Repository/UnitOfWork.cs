using StravaClone.Web.Data;
using StravaClone.Web.Interfaces;

namespace StravaClone.Web.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IClubRepository Club { get; private set; }

        public IRaceRepository Race { get; private set; }

        public IUserRepository User { get; private set; }

        public IDashboardRepository Dashboard { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Club = new ClubRepository(_context);

            Race = new RaceRepository(_context);

            User = new UserRepository(_context);

            Dashboard = new DashboardRepository(_context);
        }
    }
}
