using api.Utility.Paging;
using System.ComponentModel.DataAnnotations;

namespace api.Dtos
{
    public class CityRes
    {
        public int CityId { get; set; }
        public string? Name { get; set; }
        public int StateId { get; set; }
    }

    public class CityReqEdit
    {
        [Required, MaxLength(255)]
        public string? Name { get; set; }

        // Foreign keys
        public int StateId { get; set; }
    }

    public class CityReqSearch : PagedRequestDto
    {
        public int StateId { get; set; }
    }
}
