using ClassLibrary.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using RecipeShare.ViewModels;

namespace RecipeShare.Profiles
{
    public class DietaryTagProfile : AutoMapper.Profile
    {
        public DietaryTagProfile()
        {
            CreateMap<DietaryTag, DietaryTagViewModel>()
               .ReverseMap();

            CreateMap<DietaryTag, SelectListItem>()
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.ID));
        }
    }
}
