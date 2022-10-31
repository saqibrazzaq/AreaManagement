using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Entities
{
    [Table("Area")]
    public class Area
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(255)]
        public string? Name { get; set; }
        public string? Code { get; set; }

        // Foreign keys
        public int CityCode { get; set; }
        [ForeignKey("CityCode")]
        public City? City { get; set; }
    }
}
