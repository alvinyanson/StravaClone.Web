using Mapster;
using StravaClone.Web.Data.Enum;
using StravaClone.Web.Models;
using System.ComponentModel.DataAnnotations;

namespace StravaClone.Web.ViewModels
{
    public class EditRaceViewModel
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
        public RaceCategory RaceCategory { get; set; }
    }
}
