using ClassLibrary.Models.Extensions;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Models
{
    public class Recipe : AuditEntity
    {
        [Key]
        public Guid ID { get; set; }

        public string Title { get; set; }

        public string Ingredients { get; set; }

        public string Steps { get; set; }

        public int CookingTime { get; set; }

        public string? ImageUrl { get; set; }

        public virtual List<RecipeDietaryTag> RecipeDietaryTags { get; set; } = new List<RecipeDietaryTag>();
    }
}
