namespace CaterpillarControlService.API.Core.Models
{
    public class Shift
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? EndedAt { get; set; }
        public bool IsActive { get; set; }
        
    }
}
