using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.Win32;
using StravaClone.Web.Models;
using StravaClone.Web.ViewModels;

namespace StravaClone.Web.Profiles
{
    public class MapsterProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Race, EditRaceViewModel>()
                .Map(dest => dest.URL, src => src.Image); // Map race.Image to EditRaceViewModel.URL


            config.NewConfig<Club, EditClubViewModel>()
               .Map(dest => dest.URL, src => src.Image); // Map club.Image to EditClubViewModel.URL

            config.NewConfig<RegisterViewModel, AppUser>()
                .Map(dest => dest.UserName, src => src.EmailAddress)
                .Map(dest => dest.Email, src => src.EmailAddress);
        }
    }
}
