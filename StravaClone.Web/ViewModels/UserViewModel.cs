namespace StravaClone.Web.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public int? Pace { get; set; }
        public int? MileAge { get; set; }
        public string ProfileImageUrl { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
    }
}
