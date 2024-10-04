
using Microsoft.AspNetCore.Http;
using StravaClone.Entities.Enum;
using StravaClone.Entities.Models;

namespace StravaClone.Entities.ViewModels
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
