namespace CaterpillarControlService.API.Dtos.Planet
{
    public class PlanetToAddDto
    {
        public string Name { get; set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
    }
}
