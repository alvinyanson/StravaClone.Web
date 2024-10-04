
using StravaClone.Entities.Models;

namespace StravaClone.DataService.Interfaces
{
    public interface IIPInfoService
    {
        Task<IPInfo> GetIPInfo();
    }
}
