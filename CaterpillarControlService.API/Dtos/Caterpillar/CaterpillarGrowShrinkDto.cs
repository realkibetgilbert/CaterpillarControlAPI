using static CaterpillarControlService.API.Core.Utils.Enums.Enumeration;
using System.ComponentModel.DataAnnotations;

namespace CaterpillarControlService.API.Dtos.Caterpillar
{
    public class CaterpillarGrowShrinkDto
    {
        [Required(ErrorMessage = "The 'Growth Operation' field is required.")]
        public GrowthOperation GrowthOperation { get; set; }

        [Required(ErrorMessage = "The 'Distance' field is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "The 'Length' must be a positive integer.")]
        public int Length { get; set; }
    }
}
