﻿namespace CaterpillarControlService.API.Core.Models
{
    public class Spice
    {
        public long Id { get; set; }

        public string Reference { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public long ShiftId { get; set; }
        public Shift Shift { get; set; }

        public DateTime CollectedAt { get; set; }
    }
}