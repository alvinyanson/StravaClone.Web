using StravaClone.Entities.Models;

namespace StravaClone.DataService.Interfaces
{
    public interface IDashboardRepository
    {
        Task<List<Race>> GetAllUserRaces(string userId);
        Task<List<Club>> GetAllUserClubs(string userId);
        Task<AppUser> GetUserById(string id);
        Task<AppUser> GetByIdNoTracking(string id);
        bool Update(AppUser user);
        bool Save();
    }
}
