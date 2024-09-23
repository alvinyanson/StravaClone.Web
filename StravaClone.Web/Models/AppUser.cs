namespace StravaClone.Web.Models
{
    public class AppUser
    {
        public string Id { get; set; }
        public int? Pace { get; set; }
        public int? MileAge { get; set; }
        public Address? Address { get; set; }
        public ICollection<Club>? Clubs { get; set; }
        public ICollection<Race>? Races { get; set; }
    }
}
