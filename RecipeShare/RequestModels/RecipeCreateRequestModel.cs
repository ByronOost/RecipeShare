using System.ComponentModel.DataAnnotations;

namespace RecipeShare.RequestModels
{
    public class RecipeCreateRequestModel
    {
        public IFormFile? Image { get; set; }

        public string? ImageUrl { get; set; }

        public required string Title { get; set; }

        public required string Ingredients { get; set; }

        public required string Steps { get; set; }

        public required int CookingTime { get; set; }

        public List<Guid>? DietaryTags { get; set; }
    }
}
