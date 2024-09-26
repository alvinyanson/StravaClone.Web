using StravaClone.Web.Helpers;
using StravaClone.Web.Interfaces;

namespace StravaClone.Web.Services
{
    public class IPInfoService : IIPInfoService
    {
        private readonly HttpClient _httpClient;

        public IPInfoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://ipinfo.io");
        }

        public async Task<IPInfo> GetIPInfo()
        {
            var httpResponse = await _httpClient.GetAsync($"/?token=3f5ade860febf1");

            var ipInfo = await httpResponse.Content.ReadFromJsonAsync<IPInfo>();

            return ipInfo;
        }
    }
}
