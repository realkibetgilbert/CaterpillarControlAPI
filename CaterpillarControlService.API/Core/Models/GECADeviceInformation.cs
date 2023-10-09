namespace CaterpillarControlService.API.Core.Models
{
    public class DeviceInformation
    {
        public long Id { get; set; }
        public double batteryPercentage { get; set; }

        public double dataBalance { get; set; }
        public string deviceId { get; set; }
    }
}
