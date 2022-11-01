using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Entities
{
    [Table("Area")]
    [Index(nameof(Name), IsUnique = true)]
    [Index(nameof(Code), IsUnique = true)]
    public class Area
    {
        [Key]
        public int AreaId { get; set; }
        [Required, MaxLength(255)]
        public string? Name { get; set; }
        [Required, MaxLength(50)] 
        public string? Code { get; set; }

        // Foreign keys
        public int CityId { get; set; }
        [ForeignKey("CityId")]
        public City? City { get; set; }
    }
}
