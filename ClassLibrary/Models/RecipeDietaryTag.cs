using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ClassLibrary.Models
{
    public class RecipeDietaryTag
    {
        [Key]
        public Guid ID { get; set; }

        public Guid RecipeID { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(RecipeID))]
        public Recipe Recipe { get; set; }

        public Guid DietaryTagID { get; set; }

        [ForeignKey(nameof(DietaryTagID))]
        public DietaryTag DietaryTag { get; set; }
    }

}
