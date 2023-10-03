using System.ComponentModel.DataAnnotations;

namespace CaterpillarControlService.API.Dtos.Caterpillar
{
    public class CaterpillarToCreateDto
    {
        [Required(ErrorMessage = "The 'Name' field is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The 'Length' field is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "The 'Length' must be a positive integer.")]
        public int Length { get; set; }

        [Required(ErrorMessage = "The 'X' field is required.")]
        public int X { get; set; }

        [Required(ErrorMessage = "The 'Y' field is required.")]
        public int Y { get; set; }
    }
}
