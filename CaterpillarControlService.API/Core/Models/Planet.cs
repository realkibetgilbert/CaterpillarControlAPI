namespace CaterpillarControlService.API.Core.Models
{
    public class Planet
    {
        public long Id { get; set; }
        public string Name{ get; set; }
        public int Width { get;  set; }  
        public int Height { get;  set; }
        public List<Spice> Spices { get; set; }
    }
}
