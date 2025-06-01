using ClassLibrary.Models.Extensions;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Models
{
    public class DietaryTag : AuditEntity
    {
        [Key]
        public Guid ID { get; set; }

        public string Name { get; set; }

    }
}
