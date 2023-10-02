namespace CaterpillarControlService.API.Core.Models
{
    public class UserControlStation
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public User Rider { get; set; }
        public long ControlStationId { get; set; }
        public ControlStation ControlStation { get; set; }
        public bool IsActive { get; set; }
    }
}
