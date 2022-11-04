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
    public class CityResWithAreasCount : CityRes
    {
        public int AreasCount { get; set; }
    }

    public class CityResDetails : CityRes
    {
        public int AreasCount { get; set; }
        public string? StateName { get; set; }
        public int CountryId { get; set; }
        public string? CountryName { get; set; }
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
