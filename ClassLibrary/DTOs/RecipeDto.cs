using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.DTOs
{
    public class RecipeDto
    {
        public Guid? ID { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Ingredients are required")]
        public string Ingredients { get; set; }

        [Required(ErrorMessage = "Steps are required")]
        public string Steps { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "CookingTime must be greater than 0")]
        public int CookingTime { get; set; }

        public string? ImageUrl { get; set; }

        public List<Guid> DietaryTags { get; set; } = new();
    }
}
