using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Entities
{
    [Table("State")]
    [Index(nameof(Code), nameof(CountryId), IsUnique = true)]
    public class State
    {
        [Key]
        public int StateId { get; set; }
        [Required, MaxLength(255)]
        public string? Name { get; set; }
        [Required, MaxLength(50)]
        public string? Code { get; set; }

        // Foreign keys
        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public Country? Country { get; set; }

        // Child tables
        public IEnumerable<City>? Cities { get; set; }
    }
}
