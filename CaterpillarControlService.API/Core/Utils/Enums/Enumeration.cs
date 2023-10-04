using System.ComponentModel;
using System.Text.Json.Serialization;

namespace CaterpillarControlService.API.Core.Utils.Enums
{
    public class Enumeration
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum DirectionType
        {
            [Description("U")]
            U= 1,
            [Description("D")]
            D,
            [Description("L")]
            L,
            [Description("R")]
            R

        }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum GrowthOperation
        {
            [Description("Grow")]
            Grow=1,
            [Description("Shrink")]
            Shrink
        }

    }
}
