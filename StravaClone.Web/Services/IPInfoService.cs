﻿using Microsoft.Extensions.Options;
using StravaClone.Web.Interfaces;
using StravaClone.Web.Models;
using StravaClone.Web.Options;

namespace StravaClone.Web.Services
{
    public class IPInfoService : IIPInfoService
    {
        private readonly HttpClient _httpClient;
        private readonly IOptions<IPInfoSettings> _config;

        public IPInfoService(HttpClient httpClient, IOptions<IPInfoSettings> config)
        {
            _httpClient = httpClient;
            _config = config;
            _httpClient.BaseAddress = new Uri(_config.Value.BaseAddress);
        }

        public async Task<IPInfo> GetIPInfo()
        {
            var httpResponse = await _httpClient.GetAsync($"/?token={_config.Value.Token}");

            var ipInfo = await httpResponse.Content.ReadFromJsonAsync<IPInfo>();

            return ipInfo;
        }
    }
}
