using api.Utility.Paging;
using System.ComponentModel.DataAnnotations;

namespace api.Dtos
{
    public class StateRes
    {
        public int StateId { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public int CountryId { get; set; }
    }

    public class StateResWithCitiesCount : StateRes
    {
        public int CitiesCount { get; set; }
    }

    public class StateResWithCountryAndCitiesCount : StateRes
    {
        public string? CountryName { get; set; }
        public int CitiesCount { get; set; }
    }

    public class StateReqEdit
    {
        [Required, MaxLength(255)]
        public string? Name { get; set; }
        [Required, MaxLength(50)]
        public string? Code { get; set; }

        // Foreign keys
        public int CountryId { get; set; }
    }

    public class StateReqSearch : PagedRequestDto
    {
        public int CountryId { get; set; }
    }
}
