
using Mapster;
using Microsoft.AspNetCore.Http;
using StravaClone.Entities.Enum;
using StravaClone.Entities.Models;
using System.ComponentModel.DataAnnotations;

namespace StravaClone.Entities.ViewModels
{
    public class EditClubViewModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        [AdaptIgnore]
        [Required]
        public IFormFile Image { get; set; }
        public string? URL { get; set; }
        public int? AddressId { get; set; }
        public Address? Address { get; set; }
        public ClubCategory ClubCategory { get; set; }
        public string AppUserId { get; set; }
    }
}
