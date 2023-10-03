using System.ComponentModel.DataAnnotations;
using static CaterpillarControlService.API.Core.Utils.Enums.Enumeration;

namespace CaterpillarControlService.API.Dtos.Caterpillar
{
    public class CaterpillarMovementDto
    {
        [Required(ErrorMessage = "The 'Direction' field is required.")]
        public DirectionType Direction { get; set; }

        [Required(ErrorMessage = "The 'Distance' field is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "The 'Distance' must be a positive integer.")]
        public int Distance { get; set; }
    }
}
