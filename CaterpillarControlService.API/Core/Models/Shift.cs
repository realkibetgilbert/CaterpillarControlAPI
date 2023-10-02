namespace CaterpillarControlService.API.Core.Models
{
    public class Shift
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? EndedAt { get; set; }
        public bool IsActive { get; set; }
        public long RiderId { get; set; }
        public User Rider { get; set; }
        public long ControlStationId { get; set; }
        public ControlStation ControlStation { get; set; }
        public List<Spice> Spices { get; set; }
    }
}
