using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace StravaClone.Web.Models
{
    public class AppUser : IdentityUser
    {
        public int? Pace { get; set; }
        public int? MileAge { get; set; }
        [ForeignKey(nameof(Address))]
        public int? AddressId { get; set; }
        public Address? Address { get; set; }
        public ICollection<Club>? Clubs { get; set; }
        public ICollection<Race>? Races { get; set; }
    }
}
