using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Entities
{
    [Table("City")]
    public class City
    {
        [Key]
        public int CityId { get; set; }
        [Required, MaxLength(255)]
        public string? Name { get; set; }

        // Foreign keys
        public int StateId { get; set; }
        [ForeignKey("StateId")]
        public State? State { get; set; }

        // Chile tables
        public ICollection<Area>? Areas { get; set; }
    }
}
