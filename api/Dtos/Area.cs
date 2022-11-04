using api.Utility.Paging;
using System.ComponentModel.DataAnnotations;

namespace api.Dtos
{
    public class AreaRes
    {
        public int AreaId { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }

        // Foreign keys
        public int CityId { get; set; }
        public CityRes? City { get; set; }
    }

    public class AreaReqEdit
    {
        [Required, MaxLength(255)]
        public string? Name { get; set; }
        [Required, MaxLength(50)]
        public string? Code { get; set; }

        // Foreign keys
        public int CityId { get; set; }
    }

    public class AreaReqSearch : PagedRequestDto
    {
        public int CityId { get; set; }
    }
}
