using api.Utility.Paging;
using System.ComponentModel.DataAnnotations;

namespace api.Dtos
{
    public class CountryRes
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
    }

    public class CountryReqEdit
    {
        [Required, MaxLength(255)]
        public string? Name { get; set; }
        [Required, MaxLength(3)]
        public string? Code { get; set; }
    }

    public class CountryReqSearch : PagedRequestDto
    {

    }
}
