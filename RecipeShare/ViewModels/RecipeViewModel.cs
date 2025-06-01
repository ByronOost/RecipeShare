using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace RecipeShare.ViewModels
{
    public class RecipeIndexViewModel
    {
        public List<RecipeViewModel>? Recipes { get; set; } = new List<RecipeViewModel>();

        public List<SelectListItem>? DietaryTagsList { get; set; }
    }

    public class RecipeViewModel
    {
        public Guid? ID { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Ingredients are required.")]
        public string Ingredients { get; set; }

        [Required(ErrorMessage = "Steps are required.")]
        public string Steps { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Cooking time must be greater than 0.")]
        public int CookingTime { get; set; }

        public string? ImageUrl { get; set; }

        public List<Guid>? DietaryTags { get; set; }

        public List<SelectListItem>? DietaryTagsList { get; set; }
    }

    public class RecipeDetailsViewModel
    {
        public Guid ID { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Ingredients are required.")]
        public string Ingredients { get; set; }

        [Required(ErrorMessage = "Steps are required.")]
        public string Steps { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Cooking time must be greater than 0.")]
        public int CookingTime { get; set; }

        public string? ImageUrl { get; set; }

        public List<string>? DietaryTags { get; set; } = new List<string>();
    }

    public class RecipeCreateViewModel
    {
        public IFormFile? Image { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Ingredients are required.")]
        public string Ingredients { get; set; }

        [Required(ErrorMessage = "Steps are required.")]
        public string Steps { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Cooking time must be greater than 0.")]
        public int CookingTime { get; set; }

        public List<Guid>? DietaryTags { get; set; }

        public List<SelectListItem>? DietaryTagsList { get; set; }
    }

    public class RecipeEditViewModel
    {
        public Guid ID { get; set; }

        public IFormFile? Image { get; set; }
        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Ingredients are required.")]
        public string Ingredients { get; set; }

        [Required(ErrorMessage = "Steps are required.")]
        public string Steps { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Cooking time must be greater than 0.")]
        public int CookingTime { get; set; }

        public List<Guid>? DietaryTags { get; set; }

        public List<SelectListItem>? DietaryTagsList { get; set; }
    }
}
