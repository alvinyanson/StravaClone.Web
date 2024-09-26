using StravaClone.Web.Helpers;

namespace StravaClone.Web.Interfaces
{
    public interface IIPInfoService
    {
        Task<IPInfo> GetIPInfo();
    }
}
