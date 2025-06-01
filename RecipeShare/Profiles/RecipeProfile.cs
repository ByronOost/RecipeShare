using ClassLibrary.Models;
using RecipeShare.ViewModels;

namespace RecipeShare.Profiles
{
    public class RecipeProfile : AutoMapper.Profile
    {
        public RecipeProfile()
        {
            CreateMap<Recipe, RecipeViewModel>()
                .ForMember(dest => dest.DietaryTags, opt => opt.Ignore())
               .ReverseMap();

            CreateMap<Recipe, RecipeDetailsViewModel>()
                .ForMember(dest => dest.DietaryTags, opt => opt.Ignore())
               .ReverseMap();

            CreateMap<Recipe, RecipeCreateViewModel>()
                .ForMember(dest => dest.DietaryTags, opt => opt.Ignore())
               .ReverseMap();

            CreateMap<Recipe, RecipeEditViewModel>()
                .ForMember(dest => dest.DietaryTags, opt => opt.Ignore())
               .ReverseMap();
        }
    }
}
