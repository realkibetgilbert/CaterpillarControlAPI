using System.ComponentModel;
using System.Text.Json.Serialization;

namespace CaterpillarControlService.API.Core.Utils.Enums
{
    public class Enumeration
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum DirectionType
        {
            [Description("Up")]
            Up = 1,
            [Description("Down")]
            Down,
            [Description("Left")]
            Left,
            [Description("Right")]
            Right

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
