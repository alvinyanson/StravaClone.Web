using Microsoft.AspNetCore.Identity;

namespace StravaClone.Entities.Models
{
    public class AppUser : IdentityUser
    {
        public int? Pace { get; set; }
        public int? MileAge { get; set; }
        public string? ProfileImageUrl { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public ICollection<Club>? Clubs { get; set; }
        public ICollection<Race>? Races { get; set; }
    }
}
