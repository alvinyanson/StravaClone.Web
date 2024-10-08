﻿using Microsoft.AspNetCore.Http;

namespace StravaClone.Entities.ViewModels
{
    public class EditUserDashboardViewModel
    {
        public string Id { get; set; }
        public int? Pace { get; set; }
        public int? MileAge { get; set; }
        public string? ProfileImageUrl { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public IFormFile Image { get; set; }
    }
}
