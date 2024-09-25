﻿using StravaClone.Web.Data.Enum;
using StravaClone.Web.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace StravaClone.Web.ViewModels
{
    public class CreateClubViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Address Address { get; set; }
        public IFormFile Image { get; set; }
        public ClubCategory ClubCategory { get; set; }
        public string AppUserId { get; set; }
    }
}
