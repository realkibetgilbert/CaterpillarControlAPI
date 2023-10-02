using System.ComponentModel.DataAnnotations;

namespace CaterpillarControlService.API.Dtos.ControlStation
{
    public class ControlStationToUpdateDto
    {
        [Required]
        public string Name { get; set; }
    }
}
