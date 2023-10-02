using System.ComponentModel.DataAnnotations;

namespace CaterpillarControlService.API.Dtos.ControlStation
{
    public class ControlStationToAddDto
    {
        [Required]
        public string Name { get; set; }
    }
}
