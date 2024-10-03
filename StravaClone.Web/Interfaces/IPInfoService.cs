using StravaClone.Web.Models;

namespace StravaClone.Web.Interfaces
{
    public interface IIPInfoService
    {
        Task<IPInfo> GetIPInfo();
    }
}
